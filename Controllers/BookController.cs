using LibraryManager.Dtos;
using LibraryManager.Interfaces;
using LibraryManager.Validations;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<AuthorController> logger,IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }


        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult> CreateBook([FromBody] BookDto bookDto)
        {
            var result = await _bookService.createBook(bookDto);
            return StatusCode(result.Status,result);
        }


        [HttpGet]
        [ValidateModel]
        public async Task<ActionResult> GetBooks([FromQuery] QueryPaginationDto queryPaginationDto)
        {
            var result = await _bookService.GetBooks(queryPaginationDto);
            return StatusCode(result.Status,result);
        }
    }
}