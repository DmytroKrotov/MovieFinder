using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieFinder.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public DateTime CommentDate { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string CommentText { get; set; } = null!;

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
