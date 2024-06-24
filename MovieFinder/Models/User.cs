using System.ComponentModel.DataAnnotations.Schema;

namespace MovieFinder.Models
{
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Password { get; set; }
        public string? Phone { get; set; }

    }
}
