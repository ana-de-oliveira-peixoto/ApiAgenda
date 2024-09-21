using ApiAgenda.Handler;
using ApiAgenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private ProfissionalHandler _handler;
        public ProfissionalController(ProfissionalHandler handler)
        {
            _handler = handler;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Profissional profissionalDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var profissionais = await _handler.CriarProfissionalAsync(profissionalDTO);
            return CreatedAtAction(nameof(GetById), new { id = profissionalDTO.Id }, profissionalDTO);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profissional>>> GetAll()
        {
            var profissional= await _handler.ObterTodosAsync();
            return Ok(profissional);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Profissional>> GetById(int id)
        {
            var profissional = await _handler.ObterPorIdAsync(id);

            if (profissional == null)
                return NotFound();

            return Ok(profissional);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Profissional profissionalDTO)
        {
            if (id != profissionalDTO.Id || !ModelState.IsValid)
                return BadRequest();

            var profissionalExistente = await _handler.ObterPorIdAsync(id);
            if (profissionalExistente == null)
                return NotFound();

            await _handler.AtualizarProfissionalAsync(profissionalDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profissional = await _handler.ObterPorIdAsync(id);
            if (profissional == null)
                return NotFound();

            await _handler.DeletarProfissionalAsync(id);
            return NoContent();
        }

    }
}
