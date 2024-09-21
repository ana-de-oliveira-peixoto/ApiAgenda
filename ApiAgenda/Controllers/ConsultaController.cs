using ApiAgenda.Handler;
using ApiAgenda.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase 
    {
        private readonly ConsultaHandler _handler;
        public ConsultaController(ConsultaHandler handler)
        {
            _handler = handler;
        }
        // POST: api/consultas (Agendar Consulta)
        [HttpPost]
        public async Task<IActionResult> AgendarConsulta([FromBody] Consulta Consulta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var consulta = await _handler.AgendarConsultaAsync(Consulta);
            return CreatedAtAction(nameof(ObterConsultaPorId), new { id = consulta.Id }, consulta);
        }

        // GET: api/consultas (Listar todas as consultas)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consulta>>> ListarConsultas()
        {
            var consultas = await _handler.ListarConsultasAsync();
            return Ok(consultas);
        }

        // GET: api/consultas/{id} (Obter consulta por ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<Consulta>> ObterConsultaPorId(int id)
        {
            var consulta = await _handler.ObterConsultaPorIdAsync(id);

            if (consulta == null)
                return NotFound();

            return Ok(consulta);
        }

        // PUT: api/consultas/{id} (Alterar consulta)
        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarConsulta(int id, [FromBody] Consulta Consulta)
        {
            if (id != Consulta.Id || !ModelState.IsValid)
                return BadRequest();

            var consultaExistente = await _handler.ObterConsultaPorIdAsync(id);
            if (consultaExistente == null)
                return NotFound();

            await _handler.AlterarConsultaAsync(Consulta);
            return NoContent();
        }

        // DELETE: api/consultas/{id} (Cancelar consulta)
        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelarConsulta(int id)
        {
            var consulta = await _handler.ObterConsultaPorIdAsync(id);
            if (consulta == null)
                return NotFound();

            await _handler.CancelarConsultaAsync(id);
            return NoContent();
        }
    }
}
