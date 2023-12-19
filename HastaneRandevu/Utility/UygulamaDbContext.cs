using HastaneRandevu.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevu.Utility
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }
        public DbSet<Doktor> Doktorlar { get; set; }
    }
}
