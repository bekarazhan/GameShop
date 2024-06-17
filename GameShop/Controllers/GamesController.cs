
using GameShop.Interfaces;
using GameShop.Models;
using GameShop.Models.Filters;
using GameShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameShop.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly IGenresService _genresService;
        public GamesController(IGamesService gamesService, IGenresService genresService)
        {
            _gamesService = gamesService;
            _genresService = genresService;
        }
        public async Task<IActionResult> Index(GamesRequestFilter? filter = null)
        {

            var games =  await _gamesService.GetAllGames(filter);
            return View(games);
        }

        public async Task<IActionResult> Details(int id) {
            var game = await _gamesService.GetGameById(id);
            return View(game);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.GenreId = new SelectList(await _genresService.GetAllGenres(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameVm game) //from front
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _gamesService.CreateGame(game);
                }
                catch (Exception ex) { 
                    
                }
                return RedirectToAction("Index");
            }
                return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            await _gamesService.DeleteGame(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) {
            var gameToDelete = await _gamesService.GetGameById(id);
            if (gameToDelete == null) { 
                return NotFound();
            }
            return View(gameToDelete);
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateConfirmed(GameVm gameVm) {
            await _gamesService.UpdateGame(gameVm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id) {
            var gameToUpdate = await _gamesService.GetGameById(id);
            if (gameToUpdate == null)
            {
                return NotFound();
            }
            ViewBag.GenreId = new SelectList(await _genresService.GetAllGenres(), "Id", "Name");
            return View(gameToUpdate);
        }


    }
}
