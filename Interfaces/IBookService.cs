using LibraryManager.Dtos;
using LibraryManager.Models;

namespace LibraryManager.Interfaces
{
    public interface IBookService
    {
        Task<ResponseDto<Book>> createBook(BookDto bookDto);
        Task<ResponseDto<PaginationDto>> GetBooks(QueryPaginationDto queryPaginationDto);
    }
}