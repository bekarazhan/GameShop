using GameShop.Data;
using GameShop.Interfaces;
using GameShop.Models.Entities;

namespace GameShop.Repositories
{
    public class GenresRepository: GenericRepository<Genre>,IGenresRepository
    {
        private readonly GamesShopContext _context;
        public GenresRepository(GamesShopContext gamesShopContext):base(gamesShopContext)
        {
            _context = gamesShopContext;
        }
    }
}
