using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Dtos
{
    public class BookDto
    {
        [Required(ErrorMessage = "The title is required.")]
        [StringLength(100, ErrorMessage = "The title field cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(13, MinimumLength = 10, ErrorMessage = "The ISBN must be between 10 and 13 characters.")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "The author ID is required.")]
        [RegularExpression(@"^[{(]?[0-9A-Fa-f]{8}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{12}[)}]?$", ErrorMessage = "The AuthorId must be a valid GUID.")]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "The category ID is required.")]
        [RegularExpression(@"^[{(]?[0-9A-Fa-f]{8}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{12}[)}]?$", ErrorMessage = "The CategoryId must be a valid GUID.")]
        public Guid CategoryId { get; set; }
  
    }
}