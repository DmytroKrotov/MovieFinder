using Microsoft.AspNetCore.Mvc;

using MovieFinder.Services.DataServices;

namespace MovieFinder.Controllers
{
    public class ActorController : Controller
    {
        private IMovieDbProvider _DBProvider;
        public ActorController(IMovieDbProvider DBProvider)
        {
                _DBProvider = DBProvider;
        }
        public IActionResult Index()
        {
            var actors=_DBProvider.GetActors();
            
            return View(actors);
        }

        public IActionResult ShowActor(int id)
        {
            var actor = _DBProvider.GetActor(id);
            


            return View(actor);
        }
    }
}
