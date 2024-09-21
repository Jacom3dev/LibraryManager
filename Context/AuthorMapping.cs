using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Context
{
    public class AuthorMapping
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(author =>
            {
                author.ToTable("author");
                author.HasKey(a => a.Id);

                author.Property(a => a.Id)
                    .HasColumnName("id");

                author.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                author.Property(a => a.Status)
                    .HasDefaultValue(true)
                    .HasColumnName("status");

                author.Property(a => a.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnName("created_at");
            });
        }
    }
}