using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrcamentoFamiliar.Application.Services.Interfaces;
using OrcamentoFamiliar.Domain.Entity.Enum;
using OrcamentoFamiliar.Domain.Entity.Request;

namespace OrcamentoFamiliar.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/despesas")]
    [Authorize]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        #region Construtor
        private readonly IDespesaService _despesaService;


        public DespesasController(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }
        #endregion

        // GET: api/Despesas
        [HttpGet]
        public async Task<ActionResult> GetDespesas([FromQuery] string? descricao)
        {
            var lista = await _despesaService.GetList(descricao);
            return Ok(lista);
        }

        // GET: api/Despesas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDespesas(int id)
        {
            var despesas = await _despesaService.GetById(id);

            if (despesas == null)
                return NotFound("Despesa não encontrada");

            return Ok(despesas);
        }

        // GET: api/Despesas/2022/1
        [HttpGet("{ano}/{mes}")]
        public async Task<IActionResult> GetDespesasMes(int ano, int mes)
        {
            var result = await _despesaService.GetListMes(ano, mes);

            return Ok(result);
        }

        // PUT: api/Despesas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespesas(int id, [FromBody] DespesaRequest despesas)
        {  
            var result = await _despesaService.Update(despesas, id);
            return NoContent();
        }

        // POST: api/Despesas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDespesas([FromBody] DespesaRequest despesas)
        {
            var result = await _despesaService.Create(despesas);

            return CreatedAtAction("GetDespesas", new { id = result }, despesas);
        }

        // DELETE: api/Despesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesas(int id)
        {
            await _despesaService.Delete(id);
            return NoContent();
        }

    }
}
