using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Forms
{
    public class AddGenreNameForm
    {
        [Required]
        public string Name { get; set; }
    }
}
