namespace HastaneRandevu.Models
{
    public interface IBolumRepository : IRepository<Bolum>
    {
        void Guncelle(Bolum bl);
        void Kaydet();


    }
}
