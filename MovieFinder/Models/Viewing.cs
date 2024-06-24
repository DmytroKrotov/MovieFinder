using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models
{
    public class Viewing
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ViewingDate { get; set; }
        public User User { get; set; }
    }
}
