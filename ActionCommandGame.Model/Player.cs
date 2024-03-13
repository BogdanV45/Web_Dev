using System;
using System.Collections.Generic;
using ActionCommandGame.Model.Abstractions;

namespace ActionCommandGame.Model
{
    public class Player: IIdentifiable
    {
        public Player()
        {
            Inventory = new List<PlayerItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public int Experience { get; set; }
        public DateTime LastActionExecutedDateTime { get; set; }

        public int? CurrentEnergyPlayerItemId { get; set; }
        public PlayerItem CurrentEnergyPlayerItem { get; set; }
        public int? CurrentExploitEfficiencyPlayerItemId { get; set; }
        public PlayerItem CurrentExploitEfficiencyPlayerItem { get; set; }
        public int? CurrentSecurityPlayerItemId { get; set; }
        public PlayerItem CurrentSecurityPlayerItem { get; set; }

        public IList<PlayerItem> Inventory { get; set; }

    }
}
