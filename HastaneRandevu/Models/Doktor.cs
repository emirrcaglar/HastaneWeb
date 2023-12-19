using System.ComponentModel.DataAnnotations;

namespace HastaneRandevu.Models
{
    public class Doktor
    {
        [Key] //primary key
        public int Id { get; set; }
        [Required] //not null
        public string Ad { get; set; }
        [Required]
        public string Soyad { get; set; }
        public string Uzmanlik { get; set; }
        public string Vardiya { get; set; }
    }
}
