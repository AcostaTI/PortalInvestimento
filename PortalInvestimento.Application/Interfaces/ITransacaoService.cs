
using PortalInvestimento.Application.DTOs;

namespace PortalInvestimento.Application.Interfaces
{
    public interface ITransacaoService : IService<TransacaoDTO>
    {
        Task<IList<TransacaoDTO>> ObterTransacaoPorPortfolioId(int portfolioId);
    }
}
