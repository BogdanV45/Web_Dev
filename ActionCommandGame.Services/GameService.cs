using System;
using System.Collections.Generic;
using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Repository;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Extensions;
using ActionCommandGame.Services.Model.Core;
using ActionCommandGame.Services.Model.Results;
using ActionCommandGame.Settings;

namespace ActionCommandGame.Services
{
    public class GameService : IGameService
    {
        private readonly AppSettings _appSettings;
        private readonly ActionButtonGameDbContext _database;
        private readonly IPlayerService _playerService;
        private readonly IPositiveGameEventService _positiveGameEventService;
        private readonly INegativeGameEventService _negativeGameEventService;
        private readonly IItemService _itemService;
        private readonly IPlayerItemService _playerItemService;

        public GameService(
            AppSettings appSettings,
            ActionButtonGameDbContext database,
            IPlayerService playerService,
            IPositiveGameEventService positiveGameEventService,
            INegativeGameEventService negativeGameEventService,
            IItemService itemService,
            IPlayerItemService playerItemService)
        {
            _appSettings = appSettings;
            _database = database;
            _playerService = playerService;
            _positiveGameEventService = positiveGameEventService;
            _negativeGameEventService = negativeGameEventService;
            _itemService = itemService;
            _playerItemService = playerItemService;
        }

        public ServiceResult<GameResult> PerformAction(int playerId)
        {
            //Check Cooldown
            var player = _playerService.Get(playerId);
            var elapsedSeconds = DateTime.UtcNow.Subtract(player.LastActionExecutedDateTime).TotalSeconds;
            var cooldownSeconds = _appSettings.DefaultCooldown;
            if (player.CurrentEnergyPlayerItem != null)
            {
                cooldownSeconds = player.CurrentEnergyPlayerItem.Item.ActionCooldownSeconds;
            }

            if (elapsedSeconds < cooldownSeconds)
            {
                var waitSeconds = Math.Ceiling(cooldownSeconds - elapsedSeconds);
                var waitText = $"You are still a bit tired. You have to wait another {waitSeconds} seconds.";
                return new ServiceResult<GameResult>
                {
                    Data = new GameResult { Player = player },
                    Messages = new List<ServiceMessage> { new ServiceMessage { Code = "Cooldown", Message = waitText } }
                };
            }

            var hasExploitEfficiencyItem = player.CurrentExploitEfficiencyPlayerItem != null;
            var positiveGameEvent = _positiveGameEventService.GetRandomPositiveGameEvent(hasExploitEfficiencyItem);
            if (positiveGameEvent == null)
            {
                return new ServiceResult<GameResult>{Messages = 
                    new List<ServiceMessage>
                    {
                        new ServiceMessage
                        {
                            Code = "Error",
                            Message = "Something went wrong getting the Positive Game Event.",
                            MessagePriority = MessagePriority.Error
                        }
                    }};
            }

            var negativeGameEvent = _negativeGameEventService.GetRandomNegativeGameEvent();

            var oldLevel = player.GetLevel();

            player.Money += positiveGameEvent.Money;
            player.Experience += positiveGameEvent.Experience;

            var newLevel = player.GetLevel();

            var levelMessages = new List<ServiceMessage>();
            //Check if we leveled up
            if (oldLevel < newLevel)
            {
                levelMessages = new List<ServiceMessage>{new ServiceMessage{Code="LevelUp", Message = $"Congratulations, you arrived at level {newLevel}"}};
            }

            //Consume energy
            var energyMessages = ConsumeEnergy(player);

            var exploitEfficiencyMessages = new List<ServiceMessage>();
            //Consume exploitEfficiency when we got some loot
            if (positiveGameEvent.Money > 0)
            {
                exploitEfficiencyMessages.AddRange(ConsumeExploitEfficiency(player));
                ConsumeSecurity(player, positiveGameEvent.SecurityLoss);

            }

            var securityMessages = new List<ServiceMessage>();
            var negativeGameEventMessages = new List<ServiceMessage>();
            if (negativeGameEvent != null)
            {
                //Check security consumption
                if (player.CurrentSecurityPlayerItem != null)
                {
                    negativeGameEventMessages.Add(new ServiceMessage { Code = "SecurityWithGear", Message = negativeGameEvent.SecurityWithGearDescription });
                    securityMessages.AddRange(ConsumeSecurity(player, negativeGameEvent.SecurityLoss));
                }
                else
                {
                    negativeGameEventMessages.Add(new ServiceMessage { Code = "SecurityWithoutGear", Message = negativeGameEvent.SecurityWithoutGearDescription });

                    //If we have no security item, consume the security loss from Energy and ExploitEfficiency
                    securityMessages.AddRange(ConsumeEnergy(player, negativeGameEvent.SecurityLoss));
                    securityMessages.AddRange(ConsumeExploitEfficiency(player, negativeGameEvent.SecurityLoss));
                }
            }

            var warningMessages = GetWarningMessages(player);

            player.LastActionExecutedDateTime = DateTime.UtcNow;

            //Save Player
            _database.SaveChanges();

            var gameResult = new GameResult
            {
                Player = player,
                PositiveGameEvent = positiveGameEvent,
                NegativeGameEvent = negativeGameEvent,
                NegativeGameEventMessages = negativeGameEventMessages
            };

            var serviceResult = new ServiceResult<GameResult>
            {
                Data = gameResult
            };

            //Add all the messages to the player
            serviceResult.WithMessages(levelMessages);
            serviceResult.WithMessages(warningMessages);
            serviceResult.WithMessages(energyMessages);
            serviceResult.WithMessages(exploitEfficiencyMessages);
            serviceResult.WithMessages(securityMessages);

            return serviceResult;
        }

        public ServiceResult<BuyResult> Buy(int playerId, int itemId)
        {
            var player = _playerService.Get(playerId);
            if (player == null)
            {
                return new ServiceResult<BuyResult>().PlayerNotFound();
            }

            var item = _itemService.Get(itemId);
            if (item == null)
            {
                return new ServiceResult<BuyResult>().ItemNotFound();
            }

            if (item.Price > player.Money)
            {
                return new ServiceResult<BuyResult>().NotEnoughMoney();
            }

            _playerItemService.Create(playerId, itemId);

            player.Money -= item.Price;

            //SaveChanges
            _database.SaveChanges();

            var buyResult = new BuyResult
            {
                Player = player,
                Item = item
            };
            return new ServiceResult<BuyResult> { Data = buyResult };
        }

        private IList<ServiceMessage> ConsumeEnergy(Player player, int energyLoss = 1)
        {
            if (player.CurrentEnergyPlayerItem != null && player.CurrentEnergyPlayerItemId.HasValue)
            {
                player.CurrentEnergyPlayerItem.RemainingEnergy -= energyLoss;
                if (player.CurrentEnergyPlayerItem.RemainingEnergy <= 0)
                {
                    _playerItemService.Delete(player.CurrentEnergyPlayerItemId.Value);

                    //Load a new Energy Item from inventory
                    var newEnergyItem = player.Inventory
                        .Where(pi => pi.Item.Energy > 0)
                        .OrderByDescending(pi => pi.Item.Energy).FirstOrDefault();

                    if (newEnergyItem != null)
                    {
                        player.CurrentEnergyPlayerItem = newEnergyItem;
                        player.CurrentEnergyPlayerItemId = newEnergyItem.Id;
                        return new List<ServiceMessage>{new ServiceMessage
                        {
                            Code = "ReloadedEnergy",
                            Message = $"You are hungry and open a new {newEnergyItem.Item.Name}. Yummy!"
                        }};
                    }

                    return new List<ServiceMessage>{new ServiceMessage
                    {
                        Code = "NoFood",
                        Message = "You are so hungry. You look into your bag and find ... nothing!",
                        MessagePriority = MessagePriority.Warning
                    }};
                }
            }

            return new List<ServiceMessage>();
        }

        private IList<ServiceMessage> ConsumeExploitEfficiency(Player player, int exploitEfficiencyLoss = 1)
        {
            if (player.CurrentExploitEfficiencyPlayerItem != null && player.CurrentExploitEfficiencyPlayerItemId.HasValue)
            {
                var oldExploitEfficiencyItem = player.CurrentExploitEfficiencyPlayerItem;
                player.CurrentExploitEfficiencyPlayerItem.RemainingExploitEfficiency -= exploitEfficiencyLoss;
                if (player.CurrentExploitEfficiencyPlayerItem.RemainingExploitEfficiency <= 0)
                {
                    _playerItemService.Delete(player.CurrentExploitEfficiencyPlayerItemId.Value);

                    //Load a new ExploitEfficiency Item from inventory
                    var newExploitEfficiencyItem = player.Inventory
                        .Where(pi => pi.Item.ExploitEfficiency > 0)
                        .OrderByDescending(pi => pi.Item.ExploitEfficiency).FirstOrDefault();
                    if (newExploitEfficiencyItem != null)
                    {
                        player.CurrentExploitEfficiencyPlayerItem = newExploitEfficiencyItem;
                        player.CurrentExploitEfficiencyPlayerItemId = newExploitEfficiencyItem.Id;
                        return new List<ServiceMessage>{new ServiceMessage
                        {
                            Code = "ReloadedExploitEfficiency",
                            Message = $"You just broke {oldExploitEfficiencyItem.Item.Name}. No worries, you swiftly wield a new {newExploitEfficiencyItem.Item.Name}. Yeah!",

                        }};
                    }

                    return new List<ServiceMessage>{new ServiceMessage
                    {
                        Code = "NoExploitEfficiency",
                        Message = $"You just broke {oldExploitEfficiencyItem.Item.Name}. This was your last tool. Bummer!",
                        MessagePriority = MessagePriority.Warning
                    }};
                }
            }
            else
            {
                //If we don't have any exploit tools, just consume more energy in stead
                ConsumeEnergy(player);
            }

            return new List<ServiceMessage>();
        }

        private IList<ServiceMessage> ConsumeSecurity(Player player, int securityLoss = 1)
        {
            if (player.CurrentSecurityPlayerItem != null && player.CurrentSecurityPlayerItemId.HasValue)
            {
                var oldSecurityItem = player.CurrentSecurityPlayerItem;
                player.CurrentSecurityPlayerItem.RemainingSecurity -= securityLoss;
                if (player.CurrentSecurityPlayerItem.RemainingSecurity <= 0)
                {
                    _playerItemService.Delete(player.CurrentSecurityPlayerItemId.Value);

                    //Load a new Security Item from inventory
                    var newSecurityItem = player.Inventory
                        .Where(pi => pi.Item.Security > 0)
                        .OrderByDescending(pi => pi.Item.Security).FirstOrDefault();
                    ;
                    if (newSecurityItem != null)
                    {
                        player.CurrentSecurityPlayerItem = newSecurityItem;
                        player.CurrentSecurityPlayerItemId = newSecurityItem.Id;

                        return new List<ServiceMessage>{new ServiceMessage
                        {
                            Code = "ReloadedSecurity",
                            Message = $"Your {oldSecurityItem.Item.Name} is starting to smell. No worries, you swiftly put on a freshly washed {newSecurityItem.Item.Name}. Yeah!"
                        }};
                    }

                    return new List<ServiceMessage>{new ServiceMessage
                    {
                        Code = "NoExploitEfficiency",
                        Message = $"You just lost {oldSecurityItem.Item.Name}. You continue without protection. Did I just see something move?",
                        MessagePriority = MessagePriority.Warning
                    }};
                }
            }
            else
            {
                //If we don't have defensive gear, just consume more energy in stead.
                ConsumeEnergy(player);
            }

            return new List<ServiceMessage>();
        }

        private IList<ServiceMessage> GetWarningMessages(Player player)
        {
            var serviceMessages = new List<ServiceMessage>();

            if (player.CurrentEnergyPlayerItem == null)
            {
                var infoText = "Hacking without energy is hard. You need a long time to recover. Consider buying food from the shop.";
                serviceMessages.Add(new ServiceMessage { Code = "NoFood", Message = infoText, MessagePriority = MessagePriority.Warning });
            }
            if (player.CurrentExploitEfficiencyPlayerItem == null)
            {
                var infoText = "Hacking from an internet cafe is hard. You lost extra energy. Consider buying your own tools from the shop.";
                serviceMessages.Add(new ServiceMessage { Code = "NoTools", Message = infoText, MessagePriority = MessagePriority.Warning });
            }
            if (player.CurrentSecurityPlayerItem == null)
            {
                var infoText = "Hacking without the right security measures is dangerous. You lost extra energy. Consider buying some security items from the shop.";
                serviceMessages.Add(new ServiceMessage { Code = "NoGear", Message = infoText, MessagePriority = MessagePriority.Warning });
            }

            return serviceMessages;
        }
    }
}
