using EFCore.Data.FluentConfigs;
using EFCore.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BookDetailFromView> bookDetailFromViews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_Category> Fluent_Categories { get; set; }
        public DbSet<Fluent_BookAuthor> Fluent_BookAuthors { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
             

            base.OnModelCreating(builder);
            builder.Entity<BookAuthor>().HasKey(b => new { b.BookId, b.AuthorId });


            #region Fluent BookDetail

            builder.Entity<Fluent_BookDetail>().HasKey(b => b.BookDetailId);
            builder.Entity<Fluent_BookDetail>()
                .Property(b => b.NumberOfChapters)
                .IsRequired();


            #endregion

            #region Fluent Book
            builder.Entity<Fluent_Book>().HasKey(b => b.BookId);
            builder.Entity<Fluent_Book>().Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(15);
            builder.Entity<Fluent_Book>().Property(b => b.Title).IsRequired();
            builder.Entity<Fluent_Book>().Property(b => b.Price).IsRequired();

            builder.Entity<Fluent_Book>()
                .HasOne(b => b.Fluent_BookDetail)
                .WithOne(b => b.Fluent_Book)
                .HasForeignKey<Fluent_Book>("BookDetailId");

            builder.Entity<Fluent_Book>()
                .HasOne(b => b.Fluent_Publisher)
                .WithMany(b => b.Fluent_Books)
                .HasForeignKey(b => b.PublisherId);

            #endregion


            #region Fluent Autor

            builder.Entity<Fluent_Author>().HasKey(b => b.AuthorId);
            builder.Entity<Fluent_Author>().Property(b => b.FirstName).IsRequired();
            builder.Entity<Fluent_Author>().Property(b => b.LastName).IsRequired();

            builder.Entity<Fluent_Author>().Ignore(b => b.FullName);
            #endregion

            #region Publisher
            builder.Entity<Fluent_Publisher>().HasKey(b => b.PublisherId);
            builder.Entity<Fluent_Publisher>().Property(b => b.Name).IsRequired();
            builder.Entity<Fluent_Publisher>().Property(b => b.Location).IsRequired();
            #endregion

            #region Fuent Categoty

            builder.Entity<Fluent_Category>().HasKey(c => c.CategoryId);
            builder.Entity<Fluent_Category>().ToTable("Tbl_CategoryFluent");
            builder.Entity<Fluent_Category>().Property(c => c.Name).HasColumnName("CategoryName");

            #endregion


            #region Relation Many to Many
            builder.ApplyConfiguration(new Fluent_BookAutorsConfig());

            //builder.Entity<Fluent_BookAuthor>().HasKey(b => new { b.BookId, b.AuthorId });
            //builder.Entity<Fluent_BookAuthor>()
            //    .HasOne(b => b.Fluent_Book)
            //    .WithMany(b => b.Fluent_BookAuthors)
            //    .HasForeignKey(b => b.BookId);

            //builder.Entity<Fluent_BookAuthor>()
            //    .HasOne(b => b.Fluent_Author)
            //    .WithMany(b => b.Fluent_BookAuthors)
            //    .HasForeignKey(b => b.AuthorId);
            #endregion


            // View has no key
            builder.Entity<BookDetailFromView>().HasNoKey().ToView("GetOnlyBookDetails");
        }
    }
}
