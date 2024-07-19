using Microsoft.EntityFrameworkCore;
using MovieFinder.Data;
using MovieFinder.Models;

namespace MovieFinder.Services.DataServices
{
    public class MovieDbProvider : IMovieDbProvider
    {
        private MovieFinderDbContext _dbContext;
        public MovieDbProvider(MovieFinderDbContext db)
        {
            _dbContext = db;       
        }
        public void CreateActor(Actor actor)
        {
            _dbContext.Actors.Add(actor);
            _dbContext.SaveChanges();
        }

        public void CreateActorFact(ActorFact actorFact)
        {
            _dbContext.ActorFacts.Add(actorFact);
            _dbContext.SaveChanges();
        }

        public void CreateComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void CreateDislike(Dislike dislike)
        {
            _dbContext.Dislikes.Add(dislike);
            _dbContext.SaveChanges();
        }

        public void CreateGenre(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public void CreateGenreName(GenreName genreName)
        {
            _dbContext.GenreNames.Add(genreName);
            _dbContext.SaveChanges();
        }

        public void CreateImage(Image image)
        {
            _dbContext.Images.Add(image);
            _dbContext.SaveChanges();
        }

        public void CreateLike(Like like)
        {
            _dbContext.Likes.Add(like);
            _dbContext.SaveChanges();
        }

        public void CreateMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

        public void CreateMovieFact(MovieFact movieFact)
        {
            _dbContext.MovieFacts.Add(movieFact);
            _dbContext.SaveChanges();
        }

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void CreateViewing(Viewing viewing)
        {
            _dbContext.Viewings.Add(viewing);
            _dbContext.SaveChanges();
        }

        public void CreateWorldRating(WorldRating worldRating)
        {
            _dbContext.WorldRatings.Add(worldRating);
            _dbContext.SaveChanges();
        }

        public void CreateWorldRatingName(WorldRatingName worldRatingName)
        {
            _dbContext.WorldRatingNames.Add(worldRatingName);
            _dbContext.SaveChanges();
        }

        public void DeleteActor(int id)
        {
            var actor = _dbContext.Actors.FirstOrDefault(a => a.Id == id);
            if(actor != null)
            {
                _dbContext.Actors.Remove(actor);
                _dbContext.SaveChanges();
            }
            
        }

        public void DeleteActorFact(int id)
        {
            var actorFact = _dbContext.ActorFacts.FirstOrDefault(a => a.Id == id);
            if (actorFact != null)
            {
                _dbContext.ActorFacts.Remove(actorFact);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteComment(int id)
        {
            var comment = _dbContext.Comments.FirstOrDefault(a => a.Id == id);
            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteDislike(int id)
        {
            var dislike = _dbContext.Dislikes.FirstOrDefault(a => a.Id == id);
            if (dislike != null)
            {
                _dbContext.Dislikes.Remove(dislike);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteGenre(int id)
        {
            var genre = _dbContext.Genres.FirstOrDefault(a => a.Id == id);
            if (genre != null)
            {
                _dbContext.Genres.Remove(genre);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteGenreName(int id)
        {
            var genre = _dbContext.GenreNames.FirstOrDefault(a => a.Id == id);
            if (genre != null)
            {
                _dbContext.GenreNames.Remove(genre);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteImage(int id)
        {
            var image = _dbContext.Images.FirstOrDefault(a => a.Id == id);
            if (image != null)
            {
                _dbContext.Images.Remove(image);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteLike(int id)
        {
            var like = _dbContext.Likes.FirstOrDefault(a => a.Id == id);
            if (like != null)
            {
                _dbContext.Likes.Remove(like);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(a => a.Id == id);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteMovieFact(int id)
        {
            var movieFact = _dbContext.MovieFacts.FirstOrDefault(a => a.Id == id);
            if (movieFact != null)
            {
                _dbContext.MovieFacts.Remove(movieFact);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            
        }

        public void DeleteViewing(int id)
        {
            var viewing = _dbContext.Viewings.FirstOrDefault(a => a.Id == id);
            if (viewing != null)
            {
                _dbContext.Viewings.Remove(viewing);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteWorldRating(int id)
        {
            var worldRating = _dbContext.WorldRatings.FirstOrDefault(a => a.Id == id);
            if (worldRating != null)
            {
                _dbContext.WorldRatings.Remove(worldRating);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteWorldRatingName(int id)
        {
            var worldRating = _dbContext.WorldRatingNames.FirstOrDefault(a => a.Id == id);
            if (worldRating != null)
            {
                _dbContext.WorldRatingNames.Remove(worldRating);
                _dbContext.SaveChanges();
            }
        }

        public Actor GetActor(int id)
        {
            var actor = _dbContext.Actors.Include(i=>i.Image).Include(i => i.Movies).Include(i => i.ActorFacts).FirstOrDefault(a => a.Id == id);
            return actor;
        }

        public ActorFact GetActorFact(int id)
        {
            var actorFact = _dbContext.ActorFacts.FirstOrDefault(a => a.Id == id);
            return actorFact;
        }

        public IEnumerable<ActorFact> GetActorFacts()
        {
            return _dbContext.ActorFacts.ToList();
        }

        public IEnumerable<Actor> GetActors()
        {
            return _dbContext.Actors.Include(i=>i.Image).Include(i => i.Movies).Include(i => i.ActorFacts).ToList();
        }

        public Comment GetComment(int id)
        {
            var comment = _dbContext.Comments.FirstOrDefault(a => a.Id == id);
            return comment;
        }

        public IEnumerable<Comment> GetComments()
        {
            return _dbContext.Comments.ToList();
        }

        public IEnumerable<Dislike> GetDislikes()
        {
            return _dbContext.Dislikes.Include(d=>d.User).Include(d=>d.Movie).ToList();
        }

        public Dislike GetDislikes(int id)
        {
            var dislike = _dbContext.Dislikes.Include(d => d.User).Include(d => d.Movie).FirstOrDefault(a => a.Id == id);
            return dislike;
        }

        public Genre GetGenre(int id)
        {
            var genre = _dbContext.Genres.FirstOrDefault(a => a.Id == id);
            return genre;
        }

        public GenreName GetGenreName(int id)
        {
            var genre = _dbContext.GenreNames.FirstOrDefault(a => a.Id == id);
            return genre;
        }

        public IEnumerable<GenreName> GetGenreNames()
        {
            return _dbContext.GenreNames.ToList();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _dbContext.Genres.ToList();
        }

        public Image GetImage(int id)
        {
            var image = _dbContext.Images.FirstOrDefault(a => a.Id == id);
            return image;
        }

        public IEnumerable<Image> GetImages()
        {
            return _dbContext.Images.ToList();
        }

        public Like GetLike(int id)
        {
            var like = _dbContext.Likes.Include(d => d.User).Include(d => d.Movie).FirstOrDefault(a => a.Id == id);
            return like;
        }

        public IEnumerable<Like> GetLikes()
        {
            return _dbContext.Likes.Include(d => d.User).Include(d => d.Movie).ToList();
        }

        public Movie GetMovie(int id)
        {
            var movie = _dbContext.Movies
                .Include(i=>i.Image)
                .Include(i=>i.Images)
                .Include(i=>i.Actors)
                .Include(i => i.Likes)
                .Include(i => i.Dislikes)
                .Include(i => i.Viewings)
                .Include(i => i.Genres)
                .Include(i => i.WorldRatings)
                .Include(i=>i.MovieFacts).FirstOrDefault(a => a.Id == id);
            return movie;
        }

        public MovieFact GetMovieFact(int id)
        {
            var movieFact = _dbContext.MovieFacts.FirstOrDefault(a => a.Id == id);
            return movieFact;
        }

        public IEnumerable<MovieFact> GetMovieFacts()
        {
            return _dbContext.MovieFacts.ToList();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _dbContext.Movies
                .Include(i => i.Image)
                .Include(i => i.Images)
                .Include(i => i.Actors)
                .Include(i => i.Likes)
                .Include(i => i.Dislikes)
                .Include(i => i.Viewings)
                .Include(i => i.Genres)
                .Include(i => i.WorldRatings)
                .Include(i => i.MovieFacts).ToList();
        }

        public User GetUser(int id)
        {
            var user = new User();
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public Viewing GetViewing(int id)
        {
            var viewing = _dbContext.Viewings.FirstOrDefault(a => a.Id == id);
            return viewing;
        }

        public IEnumerable<Viewing> GetViewings()
        {
            return _dbContext.Viewings.ToList();
        }

        public WorldRating GetWorldRating(int id)
        {
            var worldRating = _dbContext.WorldRatings.FirstOrDefault(a => a.Id == id);
            return worldRating;
        }

        public WorldRatingName GetWorldRatingName(int id)
        {
            var worldRating = _dbContext.WorldRatingNames.FirstOrDefault(a => a.Id == id);
            return worldRating;
        }

        public IEnumerable<WorldRatingName> GetWorldRatingNames()
        {
            return _dbContext.WorldRatingNames.ToList();
        }

        public IEnumerable<WorldRating> GetWorldRatings()
        {
            return _dbContext.WorldRatings.ToList();
        }

        public void UpdateActor(Actor actor)
        {
            _dbContext.Actors.Update(actor);
            _dbContext.SaveChanges();
        }

        public void UpdateActorFact(ActorFact actorFact)
        {
            _dbContext.ActorFacts.Update(actorFact);
        }

        public void UpdateComment(Comment comment)
        {
            _dbContext.Comments.Update(comment);
        }

        public void UpdateDislike(Dislike dislike)
        {
            _dbContext.Dislikes.Update(dislike);
        }

        public void UpdateGenre(Genre genre)
        {
            _dbContext.Genres.Update(genre);
        }

        public void UpdateGenreName(GenreName genreName)
        {
            _dbContext.GenreNames.Update(genreName);
        }

        public void UpdateImage(Image image)
        {
            _dbContext.Images.Update(image);
        }

        public void UpdateLike(Like like)
        {
            _dbContext.Likes.Update(like);
        }

        public void UpdateMovie(Movie movie)
        {
            _dbContext.Movies.Update(movie);
            _dbContext.SaveChanges() ;
        }

        public void UpdateMovieFact(MovieFact movieFact)
        {
            _dbContext.MovieFacts.Update(movieFact);
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
        }

        public void UpdateViewing(Viewing viewing)
        {
            _dbContext.Viewings.Update(viewing);
        }

        public void UpdateWorldRating(WorldRating worldRating)
        {
            _dbContext.WorldRatings.Update(worldRating);
        }

        public void UpdateWorldRatingName(WorldRatingName worldRatingName)
        {
            _dbContext.WorldRatingNames.Update(worldRatingName);
        }
    }
}
