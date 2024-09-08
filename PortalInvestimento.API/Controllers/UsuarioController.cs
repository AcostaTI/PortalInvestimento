using Microsoft.AspNetCore.Mvc;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;
using PortalInvestimento.Application.Services;

namespace PortalInvestimento.API.Controllers
{
    [Route("Login")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;    
        }

        [HttpGet("{id:int}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            var usuario = await _usuarioService.ObterPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(usuario);
        }

        [HttpPost("adicionar_usuario")]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest(new { mensagem = "usuário inválido" });

            await _usuarioService.CadastrarAsync(usuarioDTO);

            return new CreatedAtRouteResult("GetUsuario", new { id = usuarioDTO.Id }, usuarioDTO);
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Post([FromBody] LoginDTO login)
        {
            var usuario = await _usuarioService.ObterPorNomeUsuarioESenhaAsync(login.Email, login.Senha);

            if (usuario == null)
                return NotFound(new { mensagem = "Usuario e ou Senha invalidos" });

            return Ok(new
            {
                Usuario = usuario
            });
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IList<UsuarioDTO>>> Get()
        {
            var ativos = await _usuarioService.ObterTodosAsync();
            if (ativos == null)
            {
                return NotFound("Usuários não encontrados.");
            }

            return Ok(ativos);
        }

        [HttpPut("modificar_usuario")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO ativoDTO)
        {
            if (id != ativoDTO.Id)
                return BadRequest();

            if (ativoDTO == null)
                return BadRequest();

            await _usuarioService.AlterarAsync(ativoDTO);

            return Ok(ativoDTO);
        }

        [HttpDelete("{id:int}", Name = "excluir_usuario")]
        public async Task<ActionResult> Delete(int id)
        {
            var ativoDTO = _usuarioService.ObterPorIdAsync(id);

            if (ativoDTO == null)
                return NotFound("Usuário não encontrado.");

            await _usuarioService.DeletarAsync(id);

            return Ok(ativoDTO);
        }
    }
}
