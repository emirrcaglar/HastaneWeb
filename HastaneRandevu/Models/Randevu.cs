using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevu.Models
{
    public class Randevu
    {
        public int Id { get; set; }

        public int HastaId {  get; set; }

        public int DoktorId { get; set; }
        [ForeignKey("DoktorId")]
        public Doktor Doktor { get; set; }




    }
}
