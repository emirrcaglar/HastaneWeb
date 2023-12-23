using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevu.Models
{
    public class Bolum
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Lutfen gecerli bir BOLUM giriniz.")]
        public string bolumAdi { get; set; }



    }
}
