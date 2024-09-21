using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Context
{
    public class LibraryManagerContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public LibraryManagerContext(DbContextOptions<LibraryManagerContext> options) : base(options) { }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
           AuthorMapping.Configure(modelBuilder);
           CategoryMapping.Configure(modelBuilder);
           BookMapping.Configure(modelBuilder);
        }
    }
}