using Microsoft.EntityFrameworkCore;
using RealEstateApp.Models;

namespace RealEstateApp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading
        }

        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<MultiOwner> MultiOwners { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Commune> Communes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inscription>().ToTable(nameof(Inscription))
                .HasMany(inscription => inscription.Sellers)
                .WithOne(sellers => sellers.Inscription);
            modelBuilder.Entity<Inscription>().ToTable(nameof(Inscription))
                .HasMany(inscriptions => inscriptions.Buyers)
                .WithOne(buyers => buyers.Inscription);
        }
    }
}
