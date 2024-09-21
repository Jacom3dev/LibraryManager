using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Context
{
    public class CategoryMapping
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("category");
                category.HasKey(c => c.Id);

                category.Property(c => c.Id)
                    .HasColumnName("id");

                category.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                category.Property(c => c.Status)
                    .HasDefaultValue(true)
                    .HasColumnName("status");

                category.Property(a => a.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnName("created_at");
            });
        }
    }
}