using System;
using System.Collections.Generic;
using System.Linq;
using ActionCommandGame.Model;
using ActionCommandGame.Repository;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Extensions;
using ActionCommandGame.Services.Model.Core;

namespace ActionCommandGame.Services
{
    public class PlayerItemService : IPlayerItemService
    {
        private readonly ActionButtonGameDbContext _database;

        public PlayerItemService(ActionButtonGameDbContext database)
        {
            _database = database;
        }

        public PlayerItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PlayerItem> Find(int? playerId = null)
        {
            var query = _database.PlayerItems.AsQueryable();

            if (playerId.HasValue)
            {
                query = query
                    .Where(pi => pi.PlayerId == playerId.Value);

            }



            return query.ToList();
        }

        public ServiceResult<PlayerItem> Create(int playerId, int itemId)
        {
            var player = _database.Players.SingleOrDefault(p => p.Id == playerId);
            if (player == null)
            {
                return new ServiceResult<PlayerItem>().PlayerNotFound();
            }

            var item = _database.Items.SingleOrDefault(i => i.Id == itemId);
            if (item == null)
            {
                return new ServiceResult<PlayerItem>().ItemNotFound();
            }

            var playerItem = new PlayerItem
            {
                ItemId = itemId,
                Item = item,
                PlayerId = playerId,
                Player = player
            };
            _database.PlayerItems.Add(playerItem);
            player.Inventory.Add(playerItem);
            item.PlayerItems.Add(playerItem);

            //Auto Equip the item you bought
            if (item.Energy > 0)
            {
                playerItem.RemainingEnergy = item.Energy;
                player.CurrentEnergyPlayerItemId = playerItem.Id;
                player.CurrentEnergyPlayerItem = playerItem;
            }
            if (item.ExploitEfficiency > 0)
            {
                playerItem.RemainingExploitEfficiency = item.ExploitEfficiency;
                player.CurrentExploitEfficiencyPlayerItemId = playerItem.Id;
                player.CurrentExploitEfficiencyPlayerItem = playerItem;
            }
            if (item.Security > 0)
            {
                playerItem.RemainingSecurity = item.Security;
                player.CurrentSecurityPlayerItemId = playerItem.Id;
                player.CurrentSecurityPlayerItem = playerItem;
            }

            _database.SaveChanges();

            return new ServiceResult<PlayerItem>(playerItem);
        }

        public PlayerItem Update(int id, PlayerItem playerItem)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Delete(int id)
        {
            var playerItem = _database.PlayerItems.SingleOrDefault(pi => pi.Id == id);

            if (playerItem == null)
            {
                return new ServiceResult().NotFound();
            }
            
            var player = playerItem.Player;
            player.Inventory.Remove(playerItem);
            
            var item = playerItem.Item;
            item.PlayerItems.Remove(playerItem);

            //Clear up equipment
            if (player.CurrentEnergyPlayerItemId == id)
            {
                player.CurrentEnergyPlayerItemId = null;
                player.CurrentEnergyPlayerItem = null;
            }
            if (player.CurrentExploitEfficiencyPlayerItemId == id)
            {
                player.CurrentExploitEfficiencyPlayerItemId = null;
                player.CurrentExploitEfficiencyPlayerItem = null;
            }
            if (player.CurrentSecurityPlayerItemId == id)
            {
                player.CurrentSecurityPlayerItemId = null;
                player.CurrentSecurityPlayerItem = null;
            }

            _database.PlayerItems.Remove(playerItem);

            //Save Changes
            _database.SaveChanges();

            return new ServiceResult();
        }
        
    }
}
