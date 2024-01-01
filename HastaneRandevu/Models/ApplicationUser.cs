using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevu.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string HastaAdi { get; set; }
        [Required]
        public string HastaSoyadi {  get; set; }
    }
}
