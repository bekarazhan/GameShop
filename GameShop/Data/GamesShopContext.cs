using GameShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Data
{
    public class GamesShopContext:DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gameStore.db");
        }
    }


}
