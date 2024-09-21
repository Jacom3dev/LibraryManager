using LibraryManager.Dtos;
using LibraryManager.Models;

namespace LibraryManager.Interfaces
{
    public interface ICategoryService
    {
        Task<ResponseDto<Category>> CreateCategory(CategoryDto categoryDto);
        Task<ResponseDto<PaginationDto>> GetCategories(QueryPaginationDto queryPaginationDto);
        Task<ResponseDto<Category>> GetCategoryById(Guid id);
        Task<ResponseDto<Category>> UpdateCategory(Guid id, CategoryDto categoryDto);
        Task<ResponseDto<Category>> DeleteCategory(Guid id);
    }
}