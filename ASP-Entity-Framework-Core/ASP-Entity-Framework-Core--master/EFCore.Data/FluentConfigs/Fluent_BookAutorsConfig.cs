using EFCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data.FluentConfigs
{
    public class Fluent_BookAutorsConfig : IEntityTypeConfiguration<Fluent_BookAuthor>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthor> builder)
        {
            builder.HasKey(b => new { b.BookId, b.AuthorId });
            builder.HasOne(b => b.Fluent_Book)
                .WithMany(b => b.Fluent_BookAuthors)
                .HasForeignKey(b => b.BookId);

            builder.HasOne(b => b.Fluent_Author)
                .WithMany(b => b.Fluent_BookAuthors)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
