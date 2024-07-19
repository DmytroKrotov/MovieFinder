using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Forms
{
    public class AddWorldRatingNameForm
    {
        [Required]
        public string Name { get; set; }
    }
}
