using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrcamentoFamiliar.Application.Services.Interfaces;
using OrcamentoFamiliar.Domain.Entity.Request;

namespace OrcamentoFamiliar.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/receitas")]
    [Authorize]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        #region Construtor
        private readonly IReceitaService _receitaService;

        public ReceitasController(IReceitaService receitaServices)
        {
            _receitaService = receitaServices;
        }
        #endregion

        // GET: api/Receitas
        [HttpGet]
        public async Task<IActionResult> GetReceitas([FromQuery] string? descricao)
        {
            var result = await _receitaService.GetList(descricao);
            return Ok(result);
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceitas(int id)
        {
            var result = await _receitaService.GetById(id);

            if (result == null)
                return NotFound("Receita não encontrada");

            return Ok(result);
        }

        // GET: api/Receitas/2022/1
        [HttpGet("{ano}/{mes}")]
        public async Task<IActionResult> GetReceitasMes(int ano, int mes)
        {
            var result = await _receitaService.GetListMes(ano, mes);

            return Ok(result);
        }

        // PUT: api/Receitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceitas(int id, [FromBody] ReceitaRequest receitas)
        {
            var result = await _receitaService.Update(receitas, id);

            return NoContent();
        }

        // POST: api/Receitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostReceitas([FromBody] ReceitaRequest receitas)
        {
            var result = await _receitaService.Create(receitas);

            return CreatedAtAction("GetReceitas", new { id = result }, receitas);
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceitas(int id)
        {
            await _receitaService.Delete(id);
            return NoContent();
        }

    }
}
