using System.ComponentModel.DataAnnotations;

namespace JPGZService.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}