using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class PostCreateViewModel
    {
        [Required]
        [Display(Name ="başlık")]
        public string? PostTitle {get;set;}

        [Required]
        [Display(Name ="açıklama")]
        public string? Description {get;set;}

        [Required]
        [Display(Name ="içerik")]
        public string? Content {get;set;}

        [Required]
        [Display(Name ="Url")]
        public string? Url {get;set;}




    }
}