using LibraryManager.Context;
using LibraryManager.Dtos;
using LibraryManager.Interfaces;
using LibraryManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryManagerContext _context;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;

        public BookService(LibraryManagerContext context, IAuthorService authorService, ICategoryService categoryService){
            _context = context;
            _authorService = authorService;
            _categoryService = categoryService;
        }

        public async Task<ResponseDto<Book>> createBook(BookDto bookDto){

            var getAuthor = await _authorService.GetAuthorById(bookDto.AuthorId);

            if (getAuthor.Status != 200)
            {
                return  new ResponseDto<Book>(getAuthor.Status,getAuthor.Message);
            }

            var getCategory = await _categoryService.GetCategoryById(bookDto.CategoryId);

            if (getCategory.Status != 200)
            {
                return  new ResponseDto<Book>(getCategory.Status,getCategory.Message);
            }
            

            var book = new Book
            {
                Title = bookDto.Title,
                ISBN = bookDto.ISBN,
                AuthorId = bookDto.AuthorId,
                CategoryId = bookDto.CategoryId
            };
            
            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync(); 
                return  new ResponseDto<Book>(201, "Book created successfully");
            }
            catch (Exception e)
            {
                return new ResponseDto<Book>(500,e.Message);
            }    
        }

        public async Task<ResponseDto<PaginationDto>> GetBooks(QueryPaginationDto queryPaginationDto){
            try
            {
                var totalCount = await _context.Books.CountAsync();
   
                var totalPages = (int)Math.Ceiling(totalCount / (double)queryPaginationDto.PageSize);


                var books = await _context.Books
                    .Include(book => book.Author) 
                    .Include(book => book.Category) 
                    .OrderBy(book => book.Title)
                    .Skip((queryPaginationDto.PageNumber - 1) * queryPaginationDto.PageSize)
                    .Take(queryPaginationDto.PageSize)
                    .ToListAsync();


                var pagedResult = new PaginationDto
                {
                    CurrentPage = queryPaginationDto.PageNumber,
                    TotalPages = totalPages,
                    PageSize = queryPaginationDto.PageSize,
                    TotalCount = totalCount,
                    Content = books
                };

                return new ResponseDto<PaginationDto>(200, "Books retrieved successfully",pagedResult) ;
            }
            catch (Exception e)
            {
              return new ResponseDto<PaginationDto>(500,e.Message);
            }
        }
    }
}