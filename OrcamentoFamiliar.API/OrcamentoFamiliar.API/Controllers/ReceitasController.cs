using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrcamentoFamiliar.API.Entity;
using OrcamentoFamiliar.API.Entity.Request;
using OrcamentoFamiliar.API.Entity.Response;
using OrcamentoFamiliar.API.Persistence;
using OrcamentoFamiliar.API.Services.Interfaces;

namespace OrcamentoFamiliar.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/receitas")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        #region Construtor
        private readonly IReceitaService _receitaService;
        private readonly IMapper _mapper;

        public ReceitasController(IReceitaService receitaServices, IMapper mapper)
        {
            _receitaService = receitaServices;
            _mapper = mapper;
        }
        #endregion

        // GET: api/Receitas
        [HttpGet]
        public async Task<IActionResult> GetReceitas()
        {
            var result = _mapper.Map<IList<ReceitaResponse>>(await _receitaService.GetList());

            return Ok(result);
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceitas(int id)
        {
            var result = _mapper.Map<ReceitaResponse>(await _receitaService.GetById(id));

            if (result == null)
            {
                return NotFound("Receita não encontrada");
            }

            return Ok(result);
        }

        // PUT: api/Receitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceitas(int id, [FromBody] ReceitaRequest receitas)
        {
            var income = _mapper.Map<Receitas>(receitas);

            income.Id = id;

            var result = await _receitaService.Update(income);

            return NoContent();
        }

        // POST: api/Receitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostReceitas([FromBody] ReceitaRequest receitas)
        {
            var income = _mapper.Map<Receitas>(receitas);

            var result = await _receitaService.Create(income);

            return CreatedAtAction("GetReceitas", new { id = result }, receitas);
        }

        // DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceitas(int id)
        {
            var result = await _receitaService.Delete(id);

            return NoContent();
        }

    }
}
