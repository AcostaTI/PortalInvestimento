using PortalInvestimento.Application.DTOs;

namespace PortalInvestimento.Application.Interfaces
{
    public interface IUsuarioService : IService<UsuarioDTO>
    {
        public Task<UsuarioDTO> ObterPorNomeUsuarioESenhaAsync(string email, string senha);
    }
}
