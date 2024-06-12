
using GameShop.Interfaces;
using GameShop.Models;
using GameShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameShop.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;
        public GamesController(IGamesService gamesService) {
            _gamesService = gamesService;
        }
        public async Task<IActionResult> Index()
        {
            var games =  await _gamesService.GetAllGames();
            return View(games);
        }

        public async Task<IActionResult> Details(int id) {
            var game = await _gamesService.GetGameById(id);
            return View(game);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameVm game) //from front
        {
            if (ModelState.IsValid)
            {
                await _gamesService.CreateGame(game);
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
            return View(gameToUpdate);
        }


    }
}
