using System.ComponentModel.DataAnnotations;

namespace msShop.ViewModels
{
    public class ChangeEmailViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string OldEmail { get; set; }

        [Required]
        [Display(Name = "Novo E-mail")]
        [EmailAddress]
        public string NewEmail { get; set; }
    }
}
