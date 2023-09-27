using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterViewModel
    {
    [Required]
    [Display(Name ="Username")]
    public string? UserName { get; set; }
    
    [Required]
    [Display(Name ="ad soyad")]
    public string? Name { get; set; }








        [Required]
        [EmailAddress]
        [Display(Name ="Eposta")]
        public string? Email {get;set;}

        [Required]
        [StringLength(10,ErrorMessage ="{0} alanı en az {2}, en fazla {1} karakter olamlıdır.",MinimumLength=4)]
        [DataType(DataType.Password)]
        [Display(Name ="Parola")]
        public string? Password {get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="şifrenizin aynı oldugundan emin olun.")]//karsılastırma yapıyoruz.
        [Display(Name ="Parola tekrar")]
    public string? ConfirmPassword {get;set;}


    }
}