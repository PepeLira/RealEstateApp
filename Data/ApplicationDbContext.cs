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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>().ToTable(nameof(Seller))
                .HasIndex(seller => seller.Rut)
                .IsUnique();
            modelBuilder.Entity<Buyer>().ToTable(nameof(Buyer))
                .HasIndex(buyer => buyer.Rut)
                .IsUnique();
            modelBuilder.Entity<Inscription>().ToTable(nameof(Inscription))
                .HasMany(inscription => inscription.Sellers)
                .WithMany(sellers => sellers.Inscriptions);
            modelBuilder.Entity<Inscription>().ToTable(nameof(Inscription))
                .HasMany(inscriptions => inscriptions.Buyers)
                .WithMany(buyers => buyers.Inscriptions);
        }
    }
}
