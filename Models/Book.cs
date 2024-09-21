namespace LibraryManager.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }
        public virtual Author? Author { get; set; } 

        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}