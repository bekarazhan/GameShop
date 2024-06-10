using GameShop.Data;
using GameShop.Interfaces;
using GameShop.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Repositories
{
    public class GamesRepository: GenericRepository<Game>, IGamesRepository
    {
        private readonly GamesShopContext _context;
        public GamesRepository(GamesShopContext context) : base(context)
        {
            _context = context;
        }
    }
}
