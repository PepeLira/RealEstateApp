using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using RealEstateApp.Models;

namespace RealEstateApp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }

        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<MultiOwner> MultiOwners { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>()
                .HasIndex(seller => seller.Rut)
                .IsUnique();
            modelBuilder.Entity<Buyer>()
                .HasIndex(buyer => buyer.Rut)
                .IsUnique();
            modelBuilder.Entity<Inscription>()
                .HasOne(inscription => inscription.Seller)
                .WithMany(seller => seller.Inscriptions)
                .HasForeignKey(inscription => inscription.SellerId);
            modelBuilder.Entity<Inscription>()
                .HasOne(inscription => inscription.Buyer)
                .WithMany(buyer => buyer.Inscriptions)
                .HasForeignKey(inscription => inscription.BuyerId);
        }
    }
}
