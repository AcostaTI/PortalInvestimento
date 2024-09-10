using PortalInvestimento.Domain.Entities;

namespace PortalInvestimento.Domain.Interfaces
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        Task<IList<Transacao>> ObterTransacaoPorPortfolioId(int portfolioId);
        decimal ObterSaldoPorPortfolio(int portfolioId);
    }
}
