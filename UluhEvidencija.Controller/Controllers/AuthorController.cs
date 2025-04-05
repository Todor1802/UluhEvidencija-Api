using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UluhEvidencija.Contract.IService;
using UluhEvidencija.Controller.Models;

namespace UluhEvidencija.Controller.Controllers
{
    [ApiController]
    [Route("/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }
        [HttpGet("getAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var response = await _authorService.GetAllAuthors();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var response = await _authorService.GetAuthor(id);
            return Ok(response);
        }
        [HttpPost("addAuthors")]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            var response = await _authorService.AddAuthor(_mapper.Map<Contract.Models.Author>(author));
            return Ok(response);
        }
        [HttpPut("updateAuthors")]
        public async Task<IActionResult> UpdateAuthor([FromBody] Author author)
        {
            var response = await _authorService.UpdateAuthor(_mapper.Map<Contract.Models.Author>(author));
            return Ok(response);
        }
        [HttpDelete("deleteAuthors")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var response = await _authorService.DeleteAuthor(id);
            return Ok(response);
        }
    }
}
