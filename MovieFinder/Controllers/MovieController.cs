using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Models;
using MovieFinder.Services.DataServices;

using System.Security.Claims;

namespace MovieFinder.Controllers
{
    public class MovieController : Controller
    {
        private IMovieDbProvider _DBProvider;
        private readonly UserManager<User> _userManager;
        public MovieController(IMovieDbProvider DBProvider, UserManager<User> manager)
        {
                _DBProvider = DBProvider;
            _userManager = manager;
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
        public async Task<IActionResult> AddLike(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("ShowMovie", new { id });
            }
            var likes=_DBProvider.GetLikes().Where(x=>x.MovieId == id).Where(x=>x.UserId==currentUser.Id).ToList();
            if(likes.Count==0 && currentUser != null)
            {
                var newLike = new Like();
                newLike.ClickDate = DateTime.Now;
                newLike.Movie = _DBProvider.GetMovie(id);

                newLike.User = currentUser;
                _DBProvider.CreateLike(newLike);
            }
            
            return RedirectToAction("ShowMovie",new { id });
        }

        public async Task<IActionResult> AddDislike(int id)
        {


            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return RedirectToAction("ShowMovie", new { id });
            }
            var Dislikes = _DBProvider.GetDislikes().Where(x => x.MovieId == id).Where(x => x.UserId == currentUser.Id).ToList();
            if (Dislikes.Count == 0&&currentUser!=null)
            {
                var newDislike = new Dislike();
                newDislike.ClickDate = DateTime.Now;
                newDislike.Movie = _DBProvider.GetMovie(id);
                newDislike.User = currentUser;
                _DBProvider.CreateDislike(newDislike);
            }
            return RedirectToAction("ShowMovie", new { id });
        }

        [HttpPost]
        
        public IActionResult SearchMovies()
        {
            string value = Request.Form["Search"];
            var movies = _DBProvider.GetMovies().Where(x => x.Name.ToLower().Contains(value.ToLower()) ||
            x.ShortDescription.ToLower().Contains(value.ToLower()) ||
            x.FullDescription.ToLower().Contains(value.ToLower()) ||
            x.Producer.ToLower().Contains(value.ToLower()) ||
            x.Studio.ToLower().Contains(value.ToLower())).ToList();
            

            
            

            return View(movies);
        }


    }
}
