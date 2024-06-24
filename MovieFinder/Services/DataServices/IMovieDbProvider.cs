using MovieFinder.Models;

namespace MovieFinder.Services.DataServices
{
    public interface IMovieDbProvider
    {
        //Actor/////////////////////////////////
        public IEnumerable<Actor> GetActors();
        public Actor GetActor(int id);
        public void CreateActor(Actor actor);
        public void DeleteActor(int id);
        public void UpdateActor(Actor actor);
        //ActorFact/////////////////////////////
        public IEnumerable<ActorFact> GetActorFacts();
        public ActorFact GetActorFact(int id);
        public void CreateActorFact(ActorFact actorFact);
        public void DeleteActorFact(int id);
        public void UpdateActorFact(ActorFact actorFact);
        //Comment///////////////////////////////
        public IEnumerable<Comment> GetComments();
        public Comment GetComment(int id);
        public void CreateComment(Comment comment);
        public void DeleteComment(int id);
        public void UpdateComment(Comment comment);
        //Dislike////////////////////////////////
        public IEnumerable<Dislike> GetDislikes();
        public Dislike GetDislikes(int id);
        public void CreateDislike(Dislike dislike);
        public void DeleteDislike(int id);
        public void UpdateDislike(Dislike dislike);
        //Genre//////////////////////////////////
        public IEnumerable<Genre> GetGenres();
        public Genre GetGenre(int id);
        public void CreateGenre(Genre genre);
        public void DeleteGenre(int id);
        public void UpdateGenre(Genre genre);
        //Image//////////////////////////////////
        public IEnumerable<Image> GetImages();
        public Image GetImage(int id);
        public void CreateImage(Image image);
        public void DeleteImage(int id);
        public void UpdateImage(Image image);
        //Like///////////////////////////////////
        public IEnumerable<Like> GetLikes();
        public Like GetLike(int id);
        public void CreateLike(Like like);
        public void DeleteLike(int id);
        public void UpdateLike(Like like);
        //Movie//////////////////////////////////
        public IEnumerable<Movie> GetMovies();
        public Movie GetMovie(int id);
        public void CreateMovie(Movie movie);
        public void DeleteMovie(int id);
        public void UpdateMovie(Movie movie);
        //MovieFact//////////////////////////////////
        public IEnumerable<MovieFact> GetMovieFacts();
        public MovieFact GetMovieFact(int id);
        public void CreateMovieFact(MovieFact movieFact);
        public void DeleteMovieFact(int id);
        public void UpdateMovieFact(MovieFact movieFact);
        //User////////////////////////////////////////
        
        public IEnumerable<User> GetUsers();
        public User GetUser(int id);
        public void CreateUser(User user);
        public void DeleteUser(int id);
        public void UpdateUser(User user);
        //Viewing//////////////////////////////////
        public IEnumerable<Viewing> GetViewings();
        public Viewing GetViewing(int id);
        public void CreateViewing(Viewing viewing);
        public void DeleteViewing(int id);
        public void UpdateViewing(Viewing viewing);
        //WorldRating//////////////////////////////////
        public IEnumerable<WorldRating> GetWorldRatings();
        public WorldRating GetWorldRating(int id);
        public void CreateWorldRating(WorldRating worldRating);
        public void DeleteWorldRating(int id);
        public void UpdateWorldRating(WorldRating worldRating);
    }
}
