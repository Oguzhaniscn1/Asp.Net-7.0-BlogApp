using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Eposta")]
        public string? Email {get;set;}

        [Required]
        [StringLength(10,ErrorMessage ="{0} alanı en az {2}, en fazla {1} karakter olamlıdır.",MinimumLength=4)]
        [DataType(DataType.Password)]
        [Display(Name ="Parola")]
        public string? Password {get;set;}




    }
}