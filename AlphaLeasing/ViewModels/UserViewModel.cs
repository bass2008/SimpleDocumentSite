using System.ComponentModel.DataAnnotations;

namespace AlphaLeasing.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(40, ErrorMessage = "Длина логина не должна быть больше 40 символов")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}