using ActionCommandGame.Model;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandGame.Repository.Extensions
{
    public static class RelationshipsExtensions
    {
        public static void ConfigureRelationships(this ModelBuilder builder)
        {
            builder.ConfigurePlayerItem();
            builder.ConfigurePlayer();
        }

        private static void ConfigurePlayerItem(this ModelBuilder builder)
        {
            builder.Entity<PlayerItem>()
                .HasOne(a => a.Item)
                .WithMany(u => u.PlayerItems)
                .HasForeignKey(a => a.ItemId);

            builder.Entity<PlayerItem>()
                .HasOne(a => a.Player)
                .WithMany(u => u.Inventory)
                .HasForeignKey(a => a.PlayerId);
        }

        private static void ConfigurePlayer(this ModelBuilder builder)
        {
            builder.Entity<Player>()
                .HasOne(a => a.CurrentEnergyPlayerItem)
                .WithMany(u => u.EnergyPlayers)
                .HasForeignKey(a => a.CurrentEnergyPlayerItemId);

            builder.Entity<Player>()
                .HasOne(a => a.CurrentExploitEfficiencyPlayerItem)
                .WithMany(u => u.ExploitEfficiencyPlayers)
                .HasForeignKey(a => a.CurrentExploitEfficiencyPlayerItemId);

            builder.Entity<Player>()
                .HasOne(a => a.CurrentSecurityPlayerItem)
                .WithMany(u => u.SecurityPlayers)
                .HasForeignKey(a => a.CurrentSecurityPlayerItemId);
        }
    }
}
