using HastaneRandevu.Utility;

namespace HastaneRandevu.Models
{
    public class BolumRepository : Repository<Bolum>, IBolumRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public BolumRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Bolum bl)
        { 
            _uygulamaDbContext.Update(bl);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
    }
}
