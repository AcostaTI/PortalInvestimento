﻿using Microsoft.AspNetCore.Mvc;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;

namespace PortalInvestimento.API.Controllers
{
    [Route("Transacao")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        [HttpGet("{id:int}")]
        [ActionName("obter_info_transacao")]
        public async Task<ActionResult<TransacaoDTO>> Get(int id)
        {
            var transacao = await _transacaoService.ObterPorIdAsync(id);
            if (transacao == null)
            {
                return NotFound("Transação não encontrado.");
            }

            return Ok(transacao);
        }

        [HttpGet("listar_transacao")]
        public async Task<ActionResult<IList<TransacaoDTO>>> Get()
        {
            var transacoes = await _transacaoService.ObterTodosAsync();
            if (transacoes == null)
            {
                return NotFound("Transações não encontradas.");
            }

            return Ok(transacoes);
        }

        [HttpGet("ListarTransacaoPorPortifolioId/{PortfolioId:int}")]
        [ActionName("")]
        public async Task<ActionResult<IList<TransacaoDTO>>> GetTransacoesPorId(int PortfolioId)
        {
            var transacoes = await _transacaoService.ObterTransacaoPorPortfolioId(PortfolioId);
            if (transacoes == null)
            {
                return NotFound("Transações não encontradas.");
            }

            return Ok(transacoes);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TransacaoDTO transacaoDTO)
        {
            if (transacaoDTO == null)
                return BadRequest("Transação inválido");
            
            await _transacaoService.CadastrarAsync(transacaoDTO);


            return new CreatedAtRouteResult("obter_info_transacao", new { id = transacaoDTO.Id }, transacaoDTO);
        }

        [HttpPut("modificar_transacao")]
        public async Task<ActionResult> Put(int id, [FromBody] TransacaoDTO transacaoDTO)
        {
            if (id != transacaoDTO.Id)
                return BadRequest();

            if (transacaoDTO == null)
                return BadRequest();

            await _transacaoService.AlterarAsync(transacaoDTO);

            return Ok(transacaoDTO);
        }

        [HttpDelete("excluir_trasacao/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ativoDTO = _transacaoService.ObterPorIdAsync(id);
               
            if (ativoDTO == null)
                return NotFound("Transação não encontrado.");

            await _transacaoService.DeletarAsync(id);

            return Ok(ativoDTO);
        }

    }
}
