using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Data_Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> BookList { get; set; }
        public DbSet<Ratings> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(ra => ra.User)
                .WithMany(u => u.Books)
                .HasForeignKey(ra => ra.LentByUserId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Book>()
                .HasMany(ra => ra.Ratings)
                .WithOne(u => u.Book)
                .HasForeignKey(ra => ra.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ratings>()
               .HasOne(ra => ra.User)
               .WithMany(c => c.Ratings)
               .HasForeignKey(ra => ra.UserId)
               .OnDelete(DeleteBehavior.Cascade);


         modelBuilder.Entity<User>().HasData(
           new User { UserId = 1,Name="Shahnwaz Ansari", UserName = "nagarro1", Password=BCrypt.Net.BCrypt.HashPassword("nagarro1") },
           new User { UserId = 2,Name="Nagarro-2", UserName = "nagarro2", Password = BCrypt.Net.BCrypt.HashPassword("nagarro2") },
           new User { UserId = 3, Name = "Nagarro-3", UserName = "nagarro3", Password = BCrypt.Net.BCrypt.HashPassword("nagarro3") },
           new User { UserId = 4, Name = "Nagarro-4", UserName = "nagarro4", Password = BCrypt.Net.BCrypt.HashPassword("nagarro4") }
       );

        }


    }
}
