using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAcces.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book>Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher>Publishers { get; set; }
        public DbSet<SubCategory>SubCategories { get; set; }
        public DbSet<BookDetail>BookDetails { get; set; }
        public DbSet<Fluent_BookDetail>BookDetails_Fluent { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True; ");
  */      }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetail");
            modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).HasColumnName("ChapterNumbers");
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(u=>u.NumberOfChapters).IsRequired();
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id,u.Book_Id });
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Spider Without Duty", Price = 20.99m, Publisher_Id = 1 },
                new Book { BookId = 2, Title = "Fortune of start", Price = 19.99m, Publisher_Id = 1 }
                );


            var booklist = new Book[] {
            new Book { BookId = 3, Title = "Fake Sunday ", Price = 10.99m , Publisher_Id=1},
            new Book { BookId = 4, Title = "Cookie Jar", Price = 14.99m, Publisher_Id=2 },
            new Book { BookId = 5, Title = "Coudy Forest", Price = 15.99m, Publisher_Id=2 },
            new Book { BookId = 6, Title = "Avengers and fire", Price = 17.99m, Publisher_Id=3 }
            };
            modelBuilder.Entity<Book>().HasData(booklist);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Pub 1 Bob", Location = "Chicago", },
                new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "San Fransisco"},
                new Publisher { Publisher_Id = 3, Name = "Pub 2 Jimmy", Location = "New York"}
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "cat1" },
                new Category { CategoryId = 2, CategoryName = "Cat2" },
                new Category { CategoryId = 3, CategoryName = "Cat2" }
                );


        }
    }
}
