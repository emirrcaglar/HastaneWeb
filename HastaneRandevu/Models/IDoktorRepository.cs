namespace HastaneRandevu.Models
{
    public interface IDoktorRepository : IRepository<Doktor>
    {
        void Guncelle(Doktor dt);
        void Kaydet();


    }
}
