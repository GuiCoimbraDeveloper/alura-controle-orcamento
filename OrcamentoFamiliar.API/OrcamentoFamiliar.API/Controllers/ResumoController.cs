﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrcamentoFamiliar.API.Services.Interfaces;

namespace OrcamentoFamiliar.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/resumo")]
    [ApiController]
    public class ResumoController : ControllerBase
    {
        private readonly IResumoService _resumoService;
        public ResumoController(IResumoService resumoService)
        {
            _resumoService = resumoService;
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<IActionResult> GetResumo(int ano, int mes)
        {
            return Ok(await _resumoService.GetResumo(ano, mes));
        }
    }
}
