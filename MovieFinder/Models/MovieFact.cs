using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models
{
    public class MovieFact
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Text { get; set; }

        public Movie Movie { get; set; }
    }
}
