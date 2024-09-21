using ApiAgenda.Handler;
using ApiAgenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteHandler _handler;

        public PacienteController(PacienteHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Paciente paciente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pacientes = await _handler.CriarPacienteAsync(paciente);
            return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetAll()
        {
            var pacientes = await _handler.ObterTodosAsync();
            return Ok(pacientes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetById(int id)
        {
            var paciente = await _handler.ObterPorIdAsync(id);

            if (paciente == null)
                return NotFound();

            return Ok(paciente);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.Id || !ModelState.IsValid)
                return BadRequest();

            var pacienteExistente = await _handler.ObterPorIdAsync(id);
            if (pacienteExistente == null)
                return NotFound();

            await _handler.AtualizarPacienteAsync(paciente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _handler.ObterPorIdAsync(id);
            if (paciente == null)
                return NotFound();

            await _handler.DeletarPacienteAsync(id);
            return NoContent();
        }

    }
    
}
