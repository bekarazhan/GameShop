using GameShop.Models.Filters;
using GameShop.Models.ViewModels;

namespace GameShop.Interfaces
{
    public interface IGamesService
    {
        Task DeleteGame(int id);
        Task<GameVm> CreateGame(GameVm gameVm);
        Task<List<GameVm>> GetAllGames(GamesRequestFilter? filter=null);
        Task UpdateGame(GameVm gameVm);
        Task<GameVm> GetGameById(int id);



    }
}
