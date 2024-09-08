using PortalInvestimento.Domain.Entities;

namespace PortalInvestimento.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public Task<Usuario> ObterPorNomeUsuarioESenhaAsync(string email, string senha);
    }
}
