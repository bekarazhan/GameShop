using GameShop.Interfaces;
using GameShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenreShop.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenresService _genresService;
        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }
        public async Task<IActionResult> Index()
        {

            var genres = await _genresService.GetAllGenres();
            return View(genres);
        }

        public async Task<IActionResult> Details(int id)
        {
            var genre = await _genresService.GetGenreById(id);
            return View(genre);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GenreVm genre) //from front
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _genresService.CreateGenre(genre);
                }
                catch (Exception ex)
                {

                }
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _genresService.DeleteGenre(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var genreToDelete = await _genresService.GetGenreById(id);
            if (genreToDelete == null)
            {
                return NotFound();
            }
            return View(genreToDelete);
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateConfirmed(GenreVm genreVm)
        {
            await _genresService.UpdateGenre(genreVm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var genreToUpdate = await _genresService.GetGenreById(id);
            if (genreToUpdate == null)
            {
                return NotFound();
            }
            return View(genreToUpdate);
        }
    }
}
