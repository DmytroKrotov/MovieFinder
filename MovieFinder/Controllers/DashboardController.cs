using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Models;
using MovieFinder.Models.Forms;
using MovieFinder.Services.DataServices;
using MovieFinder.Services.ImageServices;


namespace MovieFinder.Controllers
{
    [Authorize(Roles ="Admin , Manager")]
    public class DashboardController : Controller
    {
        public IMovieDbProvider DBProvider { get; set; }
        public IImageProvider _imageManager { get; set; }
        public DashboardController(IMovieDbProvider provider,IImageProvider imageManager)
        {
            DBProvider = provider;
            _imageManager = imageManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MoviesManager()
        {
           
            List<Movie> movies=DBProvider.GetMovies().ToList();
           

            return View(movies);
        }
        [HttpGet]
        public async Task<IActionResult> CreateMoviesManager()
        {
            ViewData["Actors"] = DBProvider.GetActors().ToList();
            ViewData["WorldRatingNames"] = DBProvider.GetWorldRatingNames().ToList();
            ViewData["GenreNames"] = DBProvider.GetGenreNames().ToList();
            return View(new AddMovieForm());
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoviesManager([FromForm]AddMovieForm addMovieForm)
        {
            var newMovie=new Movie();
            newMovie.Name = addMovieForm.Name;
            newMovie.Premiere = addMovieForm.Premiere;
            newMovie.Country = addMovieForm.Country;
            newMovie.Studio = addMovieForm.Studio;
            newMovie.Producer = addMovieForm.Producer;
            newMovie.FullDescription = addMovieForm.FullDescription;
            newMovie.ShortDescription = addMovieForm.ShortDescription;
            newMovie.Money = addMovieForm.Money;
            if(addMovieForm.Image != null)
            {
                var image=await _imageManager.SaveUploadedFile(addMovieForm.Image);
                DBProvider.CreateImage(image);
                newMovie.Image = image;
            }
            //newMovie.Actors=addMovieForm.Actors;
            if (addMovieForm.Actors != null)
            {
                List<Actor> actors = new List<Actor>();
                foreach (var actor in addMovieForm.Actors)
                {
                    var actorToList = DBProvider.GetActor(actor);
                   
                    actors.Add(actorToList);

                }
                newMovie.Actors = actors;
            }
            if (addMovieForm.WorldRatingNames != null)
            {
                List<WorldRating> ratings = new List<WorldRating>();
                foreach (var rating in addMovieForm.WorldRatingNames)
                {
                    var name=DBProvider.GetWorldRatingName(rating).Name;
                    var newRating = new WorldRating() { Name = name };
                    ratings.Add(newRating);

                }
                newMovie.WorldRatings = ratings;
            }

            if (addMovieForm.GenreNames != null)
            {
                List<Genre> genres = new List<Genre>();
                foreach (var genre in addMovieForm.GenreNames)
                {
                    var name = DBProvider.GetGenreName(genre).Name;
                    var newGenre = new Genre() { Name = name };
                    genres.Add(newGenre);

                }
                newMovie.Genres = genres;
            }

            newMovie.Likes=addMovieForm.Likes;
            newMovie.Dislikes=addMovieForm.Dislikes;
            newMovie.Viewings=addMovieForm.Viewings;
            if(addMovieForm.Images!=null)
            {
                newMovie.Images=new List<Models.Image>();
                foreach(var image in addMovieForm.Images)
                {
                    var newImage = await _imageManager.SaveUploadedFile(image);
                    DBProvider.CreateImage(newImage);
                    newMovie.Images.Add(newImage);
                }
            }
            newMovie.MovieFacts=addMovieForm.MovieFacts;
            newMovie.Comments=addMovieForm.Comments;


            DBProvider.CreateMovie(newMovie);

            return RedirectToAction("MoviesManager"); 
        }
        public IActionResult ActorsManager()
        {
            var actors=DBProvider.GetActors().ToList();
            return View(actors);
        }
        public IActionResult CreateActorManager()
        {
            ViewData["Movies"] = DBProvider.GetMovies().ToList();
            ViewData["ActorFacts"] = DBProvider.GetActorFacts().ToList();
            return View(new AddActorForm());
        }
        [HttpPost]
        public async Task<IActionResult> CreateActorManager([FromForm] AddActorForm form)
        {
            var newActor = new Actor();
            newActor.Name = form.Name;
            newActor.LastName = form.LastName;
            newActor.Birthday = form.Birthday;
            newActor.Country = form.Country;
            newActor.Biography = form.Biography;    
            if(form.Image != null)
            {
                var image =await _imageManager.SaveUploadedFile(form.Image);
                DBProvider.CreateImage(image);
                newActor.Image = image;
            }
            if(form.Movies!=null)
            {
                newActor.Movies = new List<Movie>();
                foreach (var id in form.Movies)
                {
                    var movie=DBProvider.GetMovie(id);
                    
                    newActor.Movies.Add(movie);
                }
            }
            if (form.ActorFacts != null)
            {
                newActor.ActorFacts = new List<ActorFact>();
                foreach (var id in form.ActorFacts)
                {
                    var fact = DBProvider.GetActorFact(id);
                    
                    newActor.ActorFacts.Add(fact);
                }
            }
            DBProvider.CreateActor(newActor);
            return RedirectToAction("ActorsManager");
        }
        public IActionResult GenreNameManager()
        {
            List<GenreName> genres=DBProvider.GetGenreNames().ToList();
            return View(genres);
        }

        public IActionResult CreateGenreNameManager()
        {
            
            return View(new AddGenreNameForm());
        }
        [HttpPost]
        public IActionResult CreateGenreNameManager([FromForm]AddGenreNameForm form)
        {
            GenreName newForm = new GenreName();
            newForm.Name = form.Name;
            DBProvider.CreateGenreName(newForm);
            return RedirectToAction("GenreNameManager");
        }


        public IActionResult WorldRatingNameManager()
        {
            List<WorldRatingName> ratings = DBProvider.GetWorldRatingNames().ToList();
            return View(ratings);
        }

        public IActionResult CreateWorldRatingNameManager()
        {

            return View(new AddWorldRatingNameForm());
        }
        [HttpPost]
        public IActionResult CreateWorldRatingNameManager([FromForm] AddWorldRatingNameForm form)
        {
            WorldRatingName newForm = new WorldRatingName();
            newForm.Name = form.Name;
            DBProvider.CreateWorldRatingName(newForm);
            return RedirectToAction("WorldRatingNameManager");
        }

        public IActionResult DeleteMovie(int id)
        {
            var movie=DBProvider.GetMovie(id);
            var image=movie.Image;
            _imageManager.RemoveFile(image);
            foreach (var item in movie.Likes)
            {
                DBProvider.DeleteLike(item.Id);
            }
            foreach (var item in movie.Dislikes)
            {
                DBProvider.DeleteDislike(item.Id);
            }
            DBProvider.DeleteImage(image.Id);
            DBProvider.DeleteMovie(id);
            return RedirectToAction("MoviesManager");
        }

        public IActionResult DeleteActor(int id)
        {
            var actor = DBProvider.GetActor(id);
            var image = actor.Image;
            _imageManager.RemoveFile(image);
            
            DBProvider.DeleteImage(image.Id);
            DBProvider.DeleteActor(id);
            return RedirectToAction("ActorsManager");
        }

        public IActionResult DeleteGenreName(int id)
        {

            var genreName=DBProvider.GetGenreName(id).Name;
            var genresToDelete=DBProvider.GetGenres().Where(x => x.Name == genreName);
            foreach (var item in genresToDelete)
            {
                DBProvider.DeleteGenre(item.Id);
            }
            DBProvider.DeleteGenreName(id);
            
            return RedirectToAction("GenreNameManager");
        }

        public IActionResult DeleteWorldRatingName(int id)
        {

            var ratingName = DBProvider.GetWorldRatingName(id).Name;
            var ratingToDelete = DBProvider.GetWorldRatings().Where(x => x.Name == ratingName);
            foreach (var item in ratingToDelete)
            {
                DBProvider.DeleteWorldRating(item.Id);
            }
            DBProvider.DeleteWorldRatingName(id);

            return RedirectToAction("WorldRatingNameManager");
        }
        [HttpGet]
        public IActionResult EditActor(int id)
        {
            var actor=DBProvider.GetActor(id);
            ViewData["Movies"] = DBProvider.GetMovies().ToList();
            ViewData["ActorFacts"] = DBProvider.GetActorFacts().ToList();

            return View(new AddActorForm(actor));
        }

        [HttpPost]
        public async  Task<IActionResult> EditActor([FromForm] AddActorForm form)
        {
            var updatedActor=DBProvider.GetActor(form.Id);
            
            //updatedActor.Id = form.Id;
            updatedActor.Name = form.Name;
            updatedActor.LastName = form.LastName;
            updatedActor.Birthday = form.Birthday;
            updatedActor.Country = form.Country;
            updatedActor.Biography = form.Biography;
            if (form.Image != null)
            {
                _imageManager.RemoveFile(updatedActor.Image);

                DBProvider.DeleteImage(updatedActor.Image.Id);

                var image = await _imageManager.SaveUploadedFile(form.Image);
                DBProvider.CreateImage(image);
                updatedActor.Image = image;
            }
            else
            {
                updatedActor.Image=updatedActor.Image;
            }
            if (form.Movies != null)
            {
                updatedActor.Movies = new List<Movie>();
                foreach (var id in form.Movies)
                {
                    var movie = DBProvider.GetMovie(id);

                    updatedActor.Movies.Add(movie);
                }
            }
            else
            {
                updatedActor.Movies=updatedActor.Movies;
            }
            if (form.ActorFacts != null)
            {
                updatedActor.ActorFacts = new List<ActorFact>();
                foreach (var id in form.ActorFacts)
                {
                    var fact = DBProvider.GetActorFact(id);

                    updatedActor.ActorFacts.Add(fact);
                }
            }
            else
            {
                updatedActor.ActorFacts=updatedActor.ActorFacts;
            }
            DBProvider.UpdateActor(updatedActor);

            return RedirectToAction("ActorsManager");
        }

       
        [HttpGet]
        public async Task<IActionResult> EditMovie(int id)
        {
            var movie=DBProvider.GetMovie(id);
            ViewData["Actors"] = DBProvider.GetActors().ToList();
            ViewData["WorldRatingNames"] = DBProvider.GetWorldRatingNames().ToList();
            ViewData["GenreNames"] = DBProvider.GetGenreNames().ToList();
            return View(new AddMovieForm(movie));
        }

        [HttpPost]
        public async Task<IActionResult> EditMovie([FromForm] AddMovieForm addMovieForm)
        {
            var newMovie = DBProvider.GetMovie(addMovieForm.Id);
            newMovie.Name = addMovieForm.Name;
            newMovie.Premiere = addMovieForm.Premiere;
            newMovie.Country = addMovieForm.Country;
            newMovie.Studio = addMovieForm.Studio;
            newMovie.Producer = addMovieForm.Producer;
            newMovie.FullDescription = addMovieForm.FullDescription;
            newMovie.ShortDescription = addMovieForm.ShortDescription;
            newMovie.Money = addMovieForm.Money;
            if (addMovieForm.Image != null)
            {
                _imageManager.RemoveFile(newMovie.Image);

                DBProvider.DeleteImage(newMovie.Image.Id);
                var image = await _imageManager.SaveUploadedFile(addMovieForm.Image);
                DBProvider.CreateImage(image);
                newMovie.Image = image;
            }
            
            //newMovie.Actors=addMovieForm.Actors;
            if (addMovieForm.Actors != null)
            {
                List<Actor> actors = new List<Actor>();
                foreach (var actor in addMovieForm.Actors)
                {
                    var actorToList = DBProvider.GetActor(actor);

                    actors.Add(actorToList);

                }
                newMovie.Actors = actors;
            }
            if (addMovieForm.WorldRatingNames != null)
            {
                List<WorldRating> ratings = new List<WorldRating>();
                foreach (var rating in addMovieForm.WorldRatingNames)
                {
                    var name = DBProvider.GetWorldRatingName(rating).Name;
                    var newRating = new WorldRating() { Name = name };
                    ratings.Add(newRating);

                }
                newMovie.WorldRatings = ratings;
            }

            if (addMovieForm.GenreNames != null)
            {
                List<Genre> genres = new List<Genre>();
                foreach (var genre in addMovieForm.GenreNames)
                {
                    var name = DBProvider.GetGenreName(genre).Name;
                    var newGenre = new Genre() { Name = name };
                    genres.Add(newGenre);

                }
                newMovie.Genres = genres;
            }

            newMovie.Likes = addMovieForm.Likes;
            newMovie.Dislikes = addMovieForm.Dislikes;
            
            newMovie.MovieFacts = addMovieForm.MovieFacts;
            newMovie.Comments = addMovieForm.Comments;


            DBProvider.UpdateMovie(newMovie);

            return RedirectToAction("MoviesManager");
        }
        public IActionResult LikesManager()
        {
            return View();
        }
        public IActionResult CommentsManager()
        {
            return View();
        }

        public IActionResult UsersManager()
        {
            return View();
        }
    }
}
