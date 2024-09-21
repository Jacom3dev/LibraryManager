using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Context
{
    public class BookMapping
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(book =>
            {
                book.ToTable("book");
                book.HasKey(b => b.Id);

                book.Property(b => b.Id)
                    .HasColumnName("id");

                book.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title");

                book.Property(b => b.ISBN)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("isbn");

                book.Property(b => b.AuthorId)
                    .IsRequired()
                    .HasColumnName("author_id");

                book.Property(b => b.CategoryId)
                   .IsRequired()
                   .HasColumnName("category_id");

                book.Property(a => a.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnName("created_at");

                book.HasOne(b => b.Author)
                    .WithMany()
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

                book.HasOne(b => b.Category)
                    .WithMany()
                    .HasForeignKey(b => b.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}