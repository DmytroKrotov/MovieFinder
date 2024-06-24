

using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime ClickDate { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }

    }
}
