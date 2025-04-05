using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UluhEvidencija.Contract.IService;
using UluhEvidencija.Controller.Models;

namespace UluhEvidencija.Controller.Controllers
{
    [ApiController]
    [Route("/painting")]
    public class PaintingController(IPaintingService painting, IMapper mapper) : ControllerBase
    {
        private readonly IPaintingService _painting = painting;
        private readonly IMapper _mapper = mapper;

        [HttpGet("getAllPaintings")]
        public async Task<IActionResult> GetAllPaintings()
        {
            var response = await _painting.GetAllPaintings();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPainting(int id)
        {
            var response = await _painting.GetPainting(id);
            return Ok(response);
        }
        [HttpPost("addPaintings")]
        public async Task<IActionResult> AddPainting([FromBody] Painting painting)
        {
            var response = await _painting.AddPainting(_mapper.Map<Contract.Models.Painting>(painting));
            return Ok(response);
        }
        [HttpPut("updatePaintings")]
        public async Task<IActionResult> UpdatePainting([FromBody] Painting painting)
        {
            var response = await _painting.UpdatePainting(_mapper.Map<Contract.Models.Painting>(painting));
            return Ok(response);
        }
        [HttpDelete("deletePaintings")]
        public async Task<IActionResult> DeletePainting(int id)
        {
            var response = await _painting.DeletePainting(id);
            return Ok(response);
        }
    }
}
