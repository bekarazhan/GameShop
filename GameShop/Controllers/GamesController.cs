
using GameShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GameShop.Controllers
{
    public class GamesController : Controller
    {
        public GamesController() { }
        public IActionResult Index()
        {
            return View();
        }

       

    }
}
