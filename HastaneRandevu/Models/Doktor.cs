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

    
    }
}
