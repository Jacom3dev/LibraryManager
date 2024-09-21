using LibraryManager.Context;
using LibraryManager.Dtos;
using LibraryManager.Interfaces;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryManagerContext _context;

        public AuthorService(LibraryManagerContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<Author>> CreateAuthor(AuthorDto authorDto){

            var author = new Author
            {
                Name = authorDto.Name,
            };
            try
            {
                _context.Authors.Add(author);
                await _context.SaveChangesAsync(); 
                return  new ResponseDto<Author>(201, "Author created successfully");
            }
            catch (Exception e)
            {
                return new ResponseDto<Author>(500,e.Message);
            }           
        }

        public async Task<ResponseDto<PaginationDto>> GetAuthors(QueryPaginationDto queryPaginationDto){
            try
            {
                var totalCount = await _context.Authors.CountAsync();
   
                var totalPages = (int)Math.Ceiling(totalCount / (double)queryPaginationDto.PageSize);


                var authors = await _context.Authors
                    .Where(author => author.Status)
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
                    Content = authors
                };

                return new ResponseDto<PaginationDto>(200, "Authors retrieved successfully",pagedResult) ;
            }
            catch (Exception e)
            {  
              return new ResponseDto<PaginationDto>(500,e.Message);
            }
        }


        public async Task<ResponseDto<Author>> GetAuthorById(Guid id){
            try
            {
                var author = await _context.Authors.FindAsync(id);
        
                if (author == null || !author.Status)
                {
                    return new ResponseDto<Author>(404, "Author not found.");
                }

                return new ResponseDto<Author>(200, "Author retrieved successfully.", author);
            }
            catch (Exception e) 
            {
                return new ResponseDto<Author>(500,e.Message);
            }
        }

        public async Task<ResponseDto<Author>> UpdateAuthor(Guid id, AuthorDto authorDto){
            try
            {
                var author = await _context.Authors.FindAsync(id);
        
                if (author == null)
                {
                    return new ResponseDto<Author>(404, "Author not found.");
                }

                author.Name = authorDto.Name;
     
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();
               return new ResponseDto<Author>(200, "Author updated successfully.", author);
            }
            catch (Exception e)
            {   
                return new ResponseDto<Author>(500,e.Message);
            }
        }

        public async Task<ResponseDto<Author>> DeleteAuthor(Guid id){
            try
            {
                var author = await _context.Authors.FindAsync(id);
        
                if (author == null)
                {
                    return new ResponseDto<Author>(404, "Author not found.");
                }

                author.Status = false;
     
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();
               return new ResponseDto<Author>(200, "Author deleted successfully.");
            }
            catch (Exception e)
            {   
                return new ResponseDto<Author>(500,e.Message);
            }
        }
    }
}