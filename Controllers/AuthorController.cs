using LibraryManager.Dtos;
using LibraryManager.Interfaces;
using LibraryManager.Validations;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    [ApiController]
    [Route("author")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService _authorService;

        public AuthorController(ILogger<AuthorController> logger,IAuthorService authorService)
        {
            _logger = logger;
            _authorService = authorService;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult> CreateAuthor([FromBody] AuthorDto authorDto)
        {
            var result = await _authorService.CreateAuthor(authorDto);
            return StatusCode(result.Status,result);
        }

        [HttpGet]
        [ValidateModel]
        public async Task<ActionResult> GetAuthors([FromQuery] QueryPaginationDto queryPaginationDto)
        {
            var result = await _authorService.GetAuthors(queryPaginationDto);
            return StatusCode(result.Status,result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuthorById(Guid id)
        {
            var result = await _authorService.GetAuthorById(id);
            return StatusCode(result.Status, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(Guid id, [FromBody] AuthorDto authorDto)
        {
            var result = await _authorService.UpdateAuthor(id,authorDto);
            return StatusCode(result.Status, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(Guid id)
        {
            var result = await _authorService.DeleteAuthor(id);
            return StatusCode(result.Status, result);
        }
    }
}