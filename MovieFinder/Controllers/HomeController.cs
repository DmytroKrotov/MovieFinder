using Microsoft.AspNetCore.Mvc;
using MovieFinder.Models;
using MovieFinder.Services.DataServices;
using System.Diagnostics;

namespace MovieFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMovieDbProvider _DBProvider;

        public HomeController(ILogger<HomeController> logger, IMovieDbProvider DBProvider)
        {
            _logger = logger;
            _DBProvider = DBProvider;
        }

        public IActionResult Index()
        {
            ViewData["BestMovie"]=_DBProvider.GetMovies().MaxBy(x=>x.Likes.Count);
            ViewData["NewMovie"]=_DBProvider.GetMovies().MaxBy(x=>x.Premiere);
            ViewData["BestActor"]=_DBProvider.GetActors().MaxBy(x=>x.Movies.Count);
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
