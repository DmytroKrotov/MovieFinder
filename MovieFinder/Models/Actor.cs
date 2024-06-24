using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieFinder.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(200)")]
        public string Name { get; set; } = null!;
        [Column(TypeName = "nvarchar(200)")]
        public string LastName { get; set; }=null!;
        [Column(TypeName = "nvarchar(200)")]
        public string Country { get; set; } = null!;

        public string Biography { get; set; } = null!;
        public DateTime Birthday { get; set; }

        public List<Movie> Movies { get; set; }
        public List<ActorFact> ActorFacts { get; set; }



    }
}
