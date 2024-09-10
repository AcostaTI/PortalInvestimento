using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;

namespace PortalInvestimento.API.Controllers
{
    [Route("Portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;

        }

        [HttpGet("{id:int}", Name = "obter_info_portfolio")]
        public async Task<ActionResult<PortfolioDTO>> Get(int id)
        {
            var ativo = await _portfolioService.ObterPorIdAsync(id);
            if (ativo == null)
            {
                return NotFound("Portfolio não encontrado.");
            }

            return Ok(ativo);
        }

        [HttpGet("listar_Portfolio")]
        public async Task<ActionResult<IList<PortfolioDTO>>> Get()
        {
            var ativos = await _portfolioService.ObterTodosAsync();
            if (ativos == null)
            {
                return NotFound("Portfolios não encontrados.");
            }

            return Ok(ativos);
        }

        [HttpPost("adicionar_portfolio")]
        public async Task<ActionResult> Post([FromBody] PortfolioDTO portfolioDTO)
        {
            if (portfolioDTO == null)
                return BadRequest("Portfolio inválido");

            await _portfolioService.CadastrarAsync(portfolioDTO);


            return Ok("OK");
        }

        [HttpPut("modificar_portfolio/{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PortfolioDTO portfolioDTO)
        {
            if (id != portfolioDTO.Id)
                return BadRequest();

            if (portfolioDTO == null)
                return BadRequest();

            await _portfolioService.AlterarAsync(portfolioDTO);

            return Ok("OK");
        }

        [HttpDelete("excluir_portfolio/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var portfolioDTO = await _portfolioService.ObterPorIdAsync(id);

            if (portfolioDTO == null)
                return NotFound("Portfolio não encontrado.");

            await _portfolioService.DeletarAsync(id);

            return Ok("OK");
        }
    }
}
