using AutoMapper;
using GameShop.Interfaces;
using GameShop.Models.Entities;
using GameShop.Models.ViewModels;
using GameShop.Repositories;

namespace GameShop.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gameRepository;
        private readonly IMapper _mapper;
        public GamesService(IGamesRepository gamesRepository)
        {
            _gameRepository = gamesRepository;
        }


        public async Task<GameVm> CreateGame(GameVm gameVm)
        {
            var game = _mapper.Map<Game>(gameVm);
            await _gameRepository.AddAsync(game);
            return gameVm;
        }

        public async Task DeleteGame(int id)
        {
            await _gameRepository.DeleteAsync(id);
        }

        public async Task<List<GameVm>> GetAllGames()
        {
            var games = await _gameRepository.ListAllAsync();
            return _mapper.Map<List<GameVm>>(games);
        }

        public async Task<GameVm> GetGameById(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            return _mapper.Map<GameVm>(game);
        }

        public async Task UpdateGame(GameVm gameVm)
        {
            var game = await _gameRepository.GetByIdAsync((int)gameVm.Id);
            if(game == null)
            {
                throw new ArgumentException("Game Not Found");
            }
            _mapper.Map(gameVm,game);
            await _gameRepository.UpdateAsync(game);
           
        }
    }
}
