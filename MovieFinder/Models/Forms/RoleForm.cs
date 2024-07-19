using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Forms
{
    public class RoleForm
    {
        [Display(Name ="Назва ролі")]
        [Required(ErrorMessage ="ROLE")]
        
        public string Name {  get; set; }

        
    }
}
