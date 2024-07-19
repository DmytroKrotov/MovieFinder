using Microsoft.AspNetCore.Mvc;
using MovieFinder.Models;
using MovieFinder.Services.DataServices;

namespace MovieFinder.Controllers
{
    public class MovieController : Controller
    {
        private IMovieDbProvider _DBProvider;
        public MovieController(IMovieDbProvider DBProvider)
        {
                _DBProvider = DBProvider;
        }
        public IActionResult Index()
        {
            var movies=_DBProvider.GetMovies();
            
            return View(movies);
        }

        public IActionResult ShowMovie(int id)
        {
            var movie = _DBProvider.GetMovie(id);
            ViewData["SimilarMovies"] = _DBProvider.GetMovies().ToList();


            return View(movie);
        }
        public IActionResult AddLike(int id)
        {
            var newLike = new Like();
            newLike.ClickDate = DateTime.Now;
            newLike.Movie = _DBProvider.GetMovie(id);
            newLike.User = _DBProvider.GetUser(1);
            _DBProvider.CreateLike(newLike);
            return RedirectToAction("ShowMovie",new { id });
        }

        public IActionResult AddDislike(int id)
        {
            var newDislike = new Dislike();
            newDislike.ClickDate = DateTime.Now;
            newDislike.Movie = _DBProvider.GetMovie(id);
            newDislike.User = _DBProvider.GetUser(1);
            _DBProvider.CreateDislike(newDislike);
            return RedirectToAction("ShowMovie", new { id });
        }


    }
}
