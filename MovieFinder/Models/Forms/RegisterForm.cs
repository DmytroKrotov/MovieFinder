using System.ComponentModel.DataAnnotations;

namespace MovieFinder.Models.Forms
{
    public class RegisterForm
    {
        [Display(Name = "Пошта")]
        [Required(ErrorMessage = "LOGIN")]
        [EmailAddress(ErrorMessage = "Логін це пошта")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введіть пароль")]
        public string Password { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введіть підтвердження пароля")]
        public string ConfirmPassword { get; set; }
    }
}
