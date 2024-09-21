using LibraryManager.Dtos;
using LibraryManager.Models;

namespace LibraryManager.Interfaces
{
    public interface IAuthorService
    {
        Task<ResponseDto<Author>> CreateAuthor(AuthorDto authorDto);
        Task<ResponseDto<PaginationDto>> GetAuthors(QueryPaginationDto queryPaginationDto);
        Task<ResponseDto<Author>> GetAuthorById(Guid id);
        Task<ResponseDto<Author>> UpdateAuthor(Guid id, AuthorDto authorDto);
        Task<ResponseDto<Author>> DeleteAuthor(Guid id);
    }
}