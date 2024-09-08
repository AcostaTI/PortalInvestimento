using Microsoft.AspNetCore.Mvc;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;

namespace PortalInvestimento.API.Controllers
{
    [Route("Ativo")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        private readonly IAtivoService _ativoService;

        public AtivoController(IAtivoService ativoService)
        {
            _ativoService = ativoService;
        }

        [HttpGet("obter_info_ativo/{id:int}")]
        public async Task<ActionResult<AtivoDTO>> Get(int id)
        {
            var ativo = await _ativoService.ObterPorIdAsync(id);
            if (ativo == null)
            {
                return NotFound("Ativo não encontrado.");
            }

            return Ok(ativo);
        }

        [HttpGet("listar_ativos")]
        public async Task<ActionResult<IList<AtivoDTO>>> Get()
        {
            var ativos = await _ativoService.ObterTodosAsync();
            if (ativos == null)
            {
                return NotFound("Ativos não encontrados.");
            }

            return Ok(ativos);
        }

        [HttpPost("adicionar_ativo")]
        public async Task<ActionResult> Post([FromBody] AtivoDTO ativoDTO)
        {
            if (ativoDTO == null)
                return BadRequest("Ativo inválido");
            
            await _ativoService.CadastrarAsync(ativoDTO);


            return new CreatedAtRouteResult("obter_info_ativo", new { id = ativoDTO.Id }, ativoDTO);
        }

        [HttpPut("modificar_ativo")]
        public async Task<ActionResult> Put(int id, [FromBody] AtivoDTO ativoDTO)
        {
            if (id != ativoDTO.Id)
                return BadRequest();

            if (ativoDTO == null)
                return BadRequest();

            await _ativoService.AlterarAsync(ativoDTO);

            return Ok(ativoDTO);
        }

        [HttpDelete("excluir_ativo/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ativoDTO = _ativoService.ObterPorIdAsync(id);
               
            if (ativoDTO == null)
                return NotFound("Ativo não encontrado.");

            await _ativoService.DeletarAsync(id);

            return Ok(ativoDTO);
        }


    }
}
