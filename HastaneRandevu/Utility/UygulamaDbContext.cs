using HastaneRandevu.Controllers;
using HastaneRandevu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevu.Utility
{
    public class UygulamaDbContext : IdentityDbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
