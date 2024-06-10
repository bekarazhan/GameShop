using GameShop.Models.ViewModels;

namespace GameShop.Interfaces
{
    public interface IGameService
    {
        Task DeleteGame(int id);
        Task<GameVm> CreateGame(GameVm gameVm);
        Task<List<GameVm>> GetAllGames();
        Task UpdateGame(int id);
        Task<GameVm> GetGameById(int id);



    }
}
