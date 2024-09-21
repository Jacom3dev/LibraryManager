using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Dtos
{
    public class CategoryDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "The name field cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
