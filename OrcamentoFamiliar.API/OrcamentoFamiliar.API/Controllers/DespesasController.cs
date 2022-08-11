using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Entity.Enum;
using OrcamentoFamiliar.API.Entity.Request;
using OrcamentoFamiliar.API.Entity.Response;
using OrcamentoFamiliar.API.Persistence;
using OrcamentoFamiliar.API.Services.Interfaces;

namespace OrcamentoFamiliar.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/despesas")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        #region Construtor
        private readonly IDespesaService _despesaService;
        private readonly IMapper _mapper;

        public DespesasController(IDespesaService despesaService, IMapper mapper)
        {
            _despesaService = despesaService;
            _mapper = mapper;
        }
        #endregion

        // GET: api/Despesas
        [HttpGet]
        public async Task<IActionResult> GetDespesas([FromQuery] string? descricao)
        {
            var result = _mapper.Map<IList<DespesaResponse>>(await _despesaService.GetList(descricao));

            return Ok(result);
        }

        // GET: api/Despesas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDespesas(int id)
        {
            var despesas = _mapper.Map<DespesaResponse>(await _despesaService.GetById(id));

            if (despesas == null)
                return NotFound("Despesa não encontrada");

            return Ok(despesas);
        }

        // GET: api/Despesas/2022/1
        [HttpGet("{ano}/{mes}")]
        public async Task<IActionResult> GetDespesasMes(int ano, int mes)
        {
            var result = _mapper.Map<IList<DespesaResponse>>(await _despesaService.GetListMes(ano, mes));

            return Ok(result);
        }

        // PUT: api/Despesas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDespesas(int id, [FromBody] DespesaRequest despesas)
        {
            var expense = _mapper.Map<Despesas>(despesas);
            expense.Id = id;

            var result = await _despesaService.Update(expense);
            return NoContent();
        }

        // POST: api/Despesas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDespesas([FromBody] DespesaRequest despesas)
        {
            if (despesas.Categoria == null)
                despesas.Categoria = EnumCategoria.Outras;

            var expense = _mapper.Map<Despesas>(despesas);

            var result = await _despesaService.Create(expense);

            return CreatedAtAction("GetDespesas", new { id = result }, despesas);
        }

        // DELETE: api/Despesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDespesas(int id)
        {
            var result = await _despesaService.Delete(id);

            return NoContent();
        }

    }
}
