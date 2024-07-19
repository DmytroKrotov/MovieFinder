using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieFinder.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Path => "/uploads/" + Name;


    }
}
