using GameShop.Models.Filters;
using GameShop.Models.ViewModels;

namespace GameShop.Interfaces
{
    public interface IGenresService
    {
        Task DeleteGenre(int id);
        Task<GenreVm> CreateGenre(GenreVm gameVm);
        Task<List<GenreVm>> GetAllGenres();
        Task UpdateGenre(GenreVm gameVm);
        Task<GenreVm> GetGenreById(int id);
    }
}
