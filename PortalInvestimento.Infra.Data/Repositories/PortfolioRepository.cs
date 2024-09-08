using Microsoft.EntityFrameworkCore;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Interfaces;
using PortalInvestimento.Infra.Data.Context;

namespace PortalInvestimento.Infra.Data.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;
        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;    
        }

        public async Task<Portfolio> AlterarAsync(Portfolio entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Portfolio> CadastrarAsync(Portfolio entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Portfolio> DeletarAsync(Portfolio entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Portfolio> ObterPorIdAsync(int? id)
        {
            return await _context.Portfolios.FindAsync(id);
        }

        public async Task<IList<Portfolio>> ObterTodosAsync()
        {
            return await _context.Portfolios.ToListAsync();
        }
    }
}
