using LibraryManager.Context;
using LibraryManager.Dtos;
using LibraryManager.Interfaces;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly LibraryManagerContext _context;

        public CategoryService(LibraryManagerContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<Category>> CreateCategory(CategoryDto categoryDto){

            var category = new Category
            {
                Name = categoryDto.Name,
            };
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync(); 
                return  new ResponseDto<Category>(201, "Category created successfully");
            }
            catch (Exception e)
            {
                return new ResponseDto<Category>(500,e.Message);
            }           
        }

        public async Task<ResponseDto<PaginationDto>> GetCategories(QueryPaginationDto queryPaginationDto){
            try
            {
                var totalCount = await _context.Categories.CountAsync();
   
                var totalPages = (int)Math.Ceiling(totalCount / (double)queryPaginationDto.PageSize);


                var categories = await _context.Categories
                    .Where(category => category.Status)
                    .OrderBy(category => category.Name)
                    .Skip((queryPaginationDto.PageNumber - 1) * queryPaginationDto.PageSize)
                    .Take(queryPaginationDto.PageSize)
                    .Select(category => new 
                    {
                        category.Id,
                        category.Name,
                        category.Status,
                        category.CreatedAt
                    })
                    .ToListAsync();


                var pagedResult = new PaginationDto
                {
                    CurrentPage = queryPaginationDto.PageNumber,
                    TotalPages = totalPages,
                    PageSize = queryPaginationDto.PageSize,
                    TotalCount = totalCount,
                    Content = categories
                };

                return new ResponseDto<PaginationDto>(200, "Categories retrieved successfully",pagedResult);
            }
            catch (Exception e)
            {  
              return new ResponseDto<PaginationDto>(500,e.Message);
            }
        }


        public async Task<ResponseDto<Category>> GetCategoryById(Guid id){
            try
            {
                var category = await _context.Categories.FindAsync(id);
        
                if (category == null || !category.Status)
                {
                    return new ResponseDto<Category>(404, "Category not found.");
                }

                return new ResponseDto<Category>(200, "Category retrieved successfully.", category);
            }
            catch (Exception e) 
            {
                return new ResponseDto<Category>(500,e.Message);
            }
        }

        public async Task<ResponseDto<Category>> UpdateCategory(Guid id, CategoryDto categoryDto){
            try
            {
                var category = await _context.Categories.FindAsync(id);
        
                if (category == null)
                {
                    return new ResponseDto<Category>(404, "Category not found.");
                }

                category.Name = categoryDto.Name;
     
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
               return new ResponseDto<Category>(200, "Category updated successfully.", category);
            }
            catch (Exception e)
            {   
                return new ResponseDto<Category>(500,e.Message);
            }
        }

        public async Task<ResponseDto<Category>> DeleteCategory(Guid id){
            try
            {
                var category = await _context.Categories.FindAsync(id);
        
                if (category == null)
                {
                    return new ResponseDto<Category>(404, "Category not found.");
                }

                category.Status = false;
     
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
               return new ResponseDto<Category>(200, "Category deleted successfully.");
            }
            catch (Exception e)
            {   
                return new ResponseDto<Category>(500,e.Message);
            }
        }
    }
}