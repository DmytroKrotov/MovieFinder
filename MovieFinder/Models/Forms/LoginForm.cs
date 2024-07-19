using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Forms
{
    public class LoginForm
    {
        [Display(Name ="Пошта")]
        [Required(ErrorMessage ="LOGIN")]
        [EmailAddress(ErrorMessage ="Логін це пошта")]
        public string Login {  get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "PASSWORD")]
        public string Password { get; set; }
    }
}
