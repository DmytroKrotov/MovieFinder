using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieFinder.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; } = null!;
        public DateTime Premiere { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Country { get; set; } = null!;
        [Column(TypeName = "nvarchar(200)")]
        public string Studio { get; set; } = null!;
        [Column(TypeName = "nvarchar(200)")]
        public string Producer { get; set; } = null!;
        public string FullDescription { get; set; } = null!;
        [Column(TypeName = "nvarchar(1000)")]
        public string ShortDescription { get; set; } = null!;
        public float Money { get; set; }
        public int ImageId { get; set; }

        public List<Actor> Actors { get; set; }
        public List<WorldRating> WorldRatings { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Like> Likes { get; set; }
        public List<Dislike> Dislikes { get; set; }
        public List<Viewing> Viewings { get; set; }
        public List<Image> Images { get; set; }
        public List<MovieFact> MovieFacts { get; set; }
        public List<Comment> Comments { get; set; }


       
        public Image Image { get; set; }

    }
}
