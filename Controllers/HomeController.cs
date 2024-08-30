using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelationsNaN.Data;
using RelationsNaN.Models;
using System.Diagnostics;

namespace RelationsNaN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RelationsNaNContext _context;

        public HomeController(ILogger<HomeController> logger, RelationsNaNContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            weshbro weshbro1 = new weshbro();
            weshbro1.games = new List<Game>();

            Game game = new Game();

            game.weshbros = new List<weshbro>();
            game.Image = "caca";
            game.Name = "pipi";
            game.ReleaseYear = 2048;

            game.weshbros.Add(weshbro1);
            game.weshbros.Add(weshbro1);

            weshbro1.games.Add(game);
            weshbro1.games.Add(game);

            await _context.weshbros.AddAsync(weshbro1);

            await _context.Game.AddAsync(game);

            await _context.SaveChangesAsync();

            game = await _context.Game.Where(g => g.Name == "pipi").FirstOrDefaultAsync();

            weshbro1 = await _context.weshbros.FirstOrDefaultAsync();

            foreach (weshbro weshbro2 in game.weshbros)
            {
                _logger.LogCritical(weshbro2.Id.ToString());
            }
            foreach (Game gam in weshbro1.games)
            {
                _logger.LogCritical(gam.Id.ToString());
            }

            _context.Game.Remove(game);

            await _context.SaveChangesAsync();

            weshbro1 = await _context.weshbros.FirstOrDefaultAsync();

            if(weshbro1.games.Count() == 0)
            {
                _logger.LogCritical("c vide");
            }
            else
            {
                foreach (Game gam in weshbro1.games)
                {
                    _logger.LogCritical(gam.Id.ToString());
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}