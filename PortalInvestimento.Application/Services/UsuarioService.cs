using AutoMapper;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PortalInvestimento.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task AlterarAsync(UsuarioDTO entidade)
        {
            var usuario = _mapper.Map<Usuario>(entidade);
            await _usuarioRepository.AlterarAsync(usuario);
        }

        public async Task CadastrarAsync(UsuarioDTO entidade)
        {
            var usuario = _mapper.Map<Usuario>(entidade);
            await _usuarioRepository.CadastrarAsync(usuario);
        }

        public async Task DeletarAsync(int? id)
        {
            var usuario = _usuarioRepository.ObterPorIdAsync(id).Result;
            await _usuarioRepository.DeletarAsync(usuario);
        }

        public async Task<UsuarioDTO> ObterPorIdAsync(int? id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<IList<UsuarioDTO>> ObterTodosAsync()
        {
            var usuario = await _usuarioRepository.ObterTodosAsync();
            return _mapper.Map<IList<UsuarioDTO>>(usuario);
        }

        public async Task<UsuarioDTO> ObterPorNomeUsuarioESenhaAsync(string email, string senha)
        {
            var usuario = await _usuarioRepository.ObterPorNomeUsuarioESenhaAsync(email, senha);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        //private string CriptografarSenha(string senha)
        //{
        //    var encodedValue = Encoding.UTF8.GetBytes(senha);
        //    var encryptedPassword = _algoritmo.ComputeHash(encodedValue);

        //    var sb = new StringBuilder();
        //    foreach (var caracter in encryptedPassword)
        //    {
        //        sb.Append(caracter.ToString("X9"));
        //    }

        //    return sb.ToString();
        //}

        //private bool VerificarSenha(string senhaDigitada, string senhaCadastrada)
        //{
        //    if (string.IsNullOrEmpty(senhaCadastrada))
        //        throw new NullReferenceException("Cadastre uma senha.");

        //    var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));

        //    var sb = new StringBuilder();
        //    foreach (var caractere in encryptedPassword)
        //    {
        //        sb.Append(caractere.ToString("X9"));
        //    }

        //    return sb.ToString() == senhaCadastrada;
        //}

    }
      
}
   