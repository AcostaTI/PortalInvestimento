using Microsoft.EntityFrameworkCore;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Interfaces;
using PortalInvestimento.Infra.Data.Context;

namespace PortalInvestimento.Infra.Data.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly ApplicationDbContext _context;
        public TransacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transacao> AlterarAsync(Transacao entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Transacao> CadastrarAsync(Transacao entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public void Deletar(Transacao entidade)
        {
            _context.Remove(entidade);
            _context.SaveChanges();
        }

        public async Task<Transacao> DeletarAsync(Transacao entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Transacao> ObterPorIdAsync(int? id)
        {
            var result = await _context.Transacoes.FindAsync(id);
            return result;            
        }

        public async Task<IList<Transacao>> ObterTodosAsync()
        {
            return await _context.Transacoes.ToListAsync();
        }

        public async Task<IList<Transacao>> ObterTransacaoPorPortfolioId(int portfolioId)
        {
            return await _context.Transacoes.Where(t => t.PortfolioId == portfolioId).ToListAsync();
        }

        public decimal ObterSaldoPorPortfolio(int portfolioId)
        {
            decimal aporte =  _context.Transacoes.Where(t => t.PortfolioId == portfolioId && t.Operacao == "A").Sum(s => s.Total);
            decimal resgate =  _context.Transacoes.Where(t => t.PortfolioId == portfolioId && t.Operacao == "R").Sum(s => s.Total);

            var result = aporte - resgate;
            return result;
        }

    }
}
