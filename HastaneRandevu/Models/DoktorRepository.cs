using HastaneRandevu.Utility;

namespace HastaneRandevu.Models
{
    public class DoktorRepository : Repository<Doktor>, IDoktorRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public DoktorRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Doktor dt)
        {
            _uygulamaDbContext.Update(dt);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
