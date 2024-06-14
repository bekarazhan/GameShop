using AutoMapper;
using GameShop.Interfaces;
using GameShop.Models.Entities;
using GameShop.Models.Filters;
using GameShop.Models.ViewModels;
using GameShop.Repositories;

namespace GameShop.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gameRepository;
        private readonly IMapper _mapper;
        public GamesService(
            IGamesRepository gamesRepository,
            IMapper mapper)
        {
            _gameRepository = gamesRepository;
            _mapper = mapper;
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

        public async Task<List<GameVm>> GetAllGames(GamesRequestFilter? filter=null)
        {
            var games = await _gameRepository.ListAllAsync();
            
            if (filter == null) {

                goto GamesResult;
            }
            if (filter.SortingType is not null) {
                switch (filter.SortingType)
                {
                    case "name":
                        games = games.OrderBy(x => x.Name).ToList();
                        break;
                    case "name_desc":
                        games = games.OrderByDescending(x => x.Name).ToList();
                        break;
                    case "price":
                        games = games.OrderBy(y => y.Price).ToList();
                        break;
                    case "price_desc":
                        games = games.OrderByDescending(y => y.Price).ToList();
                        break;
                    default:
                        break;
                }
            }


            GamesResult:
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
