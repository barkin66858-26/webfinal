using Microsoft.EntityFrameworkCore;
using FitnessApp.Models;

namespace FitnessApp.Data
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Member> Members { get; set; } // New Table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed Admin User
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "barkin", Password = "123", IsAdmin = true }
            );

            // Seed Initial Packages
            modelBuilder.Entity<Package>().HasData(
                new Package { 
                    Id = 1, 
                    Name = "Basic Paket", 
                    Price = 500, 
                    Description = "Başlangıç için ideal.", 
                    ImageUrl = "https://images.unsplash.com/photo-1534438327276-14e5300c3a48", 
                    Features = "Haftada 2 Gün Kullanım,Antrenman Programı,Beslenme Programı,7/24 WhatsApp Desteği" 
                },
                new Package { 
                    Id = 2, 
                    Name = "Pro Paket", 
                    Price = 1000, 
                    Description = "Düzenli spor yapanlar için.", 
                    ImageUrl = "https://images.unsplash.com/photo-1517836357463-d25dfeac3438", 
                    Features = "Haftada 4 Gün Kullanım,Antrenman Programı,Beslenme Programı,Supplement Çekilişi Hakkı" 
                },
                new Package { 
                    Id = 3, 
                    Name = "Elite Paket", 
                    Price = 2000, 
                    Description = "Tam kapsamlı profesyonel destek.", 
                    ImageUrl = "https://images.unsplash.com/photo-1599058945522-28d584b6f0ff", 
                    Features = "Birebir Yüz Yüze Ders,Grup Dersleri,Beslenme & Antrenman Programı,7/24 WhatsApp Desteği,Supplement ve Üyelik Çekilişleri" 
                }
            );
        }
    }
}
