using LibraryManager.Models;

namespace LibraryManager.Dtos
{
    public class PaginationDto
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<object> Content { get; set; } = new List<object>();
    }
}