using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevu.Models
{
    public class Doktor
    {
        [Key] //primary key
        public int Id { get; set; }

        [Required(ErrorMessage = "Lutfen gecerli bir AD giriniz.")]
        [MaxLength(25)]
        public string ad { get; set; }

        [Required(ErrorMessage = "Lutfen gecerli bir SOYAD giriniz.")]
        [MaxLength(30)]
        public string soyad { get; set; }

        [ValidateNever]
        public int BolumId { get; set; }
        [ValidateNever]
        [ForeignKey("BolumId")]
        public Bolum? Bolum { get; set;}

    
    }
}
