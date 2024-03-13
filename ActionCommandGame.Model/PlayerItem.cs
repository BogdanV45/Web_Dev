using System.Collections.Generic;
using ActionCommandGame.Model.Abstractions;

namespace ActionCommandGame.Model
{
    public class PlayerItem: IIdentifiable
    {
        public PlayerItem()
        {
            EnergyPlayers = new List<Player>();
            ExploitEfficiencyPlayers = new List<Player>();
            SecurityPlayers = new List<Player>();
        }

        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int RemainingEnergy { get; set; }
        public int RemainingExploitEfficiency { get; set; }
        public int RemainingSecurity { get; set; }

        public IList<Player> EnergyPlayers { get; set; }
        public IList<Player> ExploitEfficiencyPlayers { get; set; }
        public IList<Player> SecurityPlayers { get; set; }
    }
}
