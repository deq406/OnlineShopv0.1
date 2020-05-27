using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Models.Interfaces;


namespace Online_Shop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Goods> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JWT> JWTs { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<UserBasket> UserBaskets { get; set; }
      
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Login);

            modelBuilder.Entity<UserBasket>()
                .HasKey(b => b.UserLogin);

            modelBuilder.Entity<UserBasket>()
                .HasOne(b => b.User)
                .WithMany(b => b.UserBaskets)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserBasket>()
                .HasOne(b => b.Basket)
                .WithMany(b => b.UserBaskets)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<UserBasket>()
            //    .HasOne(b => b.Item)
            //    .WithMany(b => b.UserBaskets)
            //    .OnDelete(DeleteBehavior.Cascade);
                
            modelBuilder.Entity<User>()
                .HasOne(u => u.JWT)
                .WithOne(t => t.User)
                .HasForeignKey<JWT>(t => t.UserLogin)
                .OnDelete(DeleteBehavior.Cascade);



            
        }
    }
}
