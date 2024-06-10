using GameShop.Interfaces;
using GameShop.Models.ViewModels;
using GameShop.Repositories;

namespace GameShop.Services
{
    public class GamesService : IGameService
    {
        private readonly IGamesRepository _gameRepository;
        public GamesService(IGamesRepository gamesRepository)
        {
            _gameRepository = gamesRepository;
        }






        public Task<GameVm> CreateGame(GameVm gameVm)
        {
            _gameRepository.AddAsync(gameVm);
        }

        public Task DeleteGame(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameVm>> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public async Task<GameVm> GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGame(int id)
        {
            throw new NotImplementedException();
        }
    }
}
