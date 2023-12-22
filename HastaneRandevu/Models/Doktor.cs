using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Lutfen gecerli bir UZMANLIK ALANI giriniz.")]
        public string uzmanlik { get; set; }

        [Required(ErrorMessage = "Lutfen gecerli bir VARDIYA giriniz.")]
        [Range(1, 3)]
        public string vardiya { get; set; }
    }
}
