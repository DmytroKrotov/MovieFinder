using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MovieFinder.Models;

namespace MovieFinder.Data
{
    public class MovieFinderDbContext: IdentityDbContext<User,IdentityRole<int>,int>
    {
        public MovieFinderDbContext(DbContextOptions<MovieFinderDbContext> option):base(option)
        {
               
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorFact> ActorFacts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Dislike> Dislikes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreName> GenreNames { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieFact> MovieFacts { get; set; }
        
        public DbSet<Viewing> Viewings { get; set; }
        public DbSet<WorldRating> WorldRatings { get; set; }
        public DbSet<WorldRatingName> WorldRatingNames { get; set; }
    }
}
