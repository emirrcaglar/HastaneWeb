using System.ComponentModel.DataAnnotations;

namespace HastaneRandevu.Models
{
    public class Doktor
    {
        [Key] //primary key
        public int Id { get; set; }
        [Required] //not null
        public string ad { get; set; }
        [Required]
        public string soyad { get; set; }
        public string uzmanlik { get; set; }
        public string vardiya { get; set; }
    }
}
