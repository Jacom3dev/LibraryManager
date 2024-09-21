using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace LibraryManager.Dtos
{
    public class QueryPaginationDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than 0.")]
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; } = 1; 

        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 10; 
    }
}