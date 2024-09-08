using Microsoft.EntityFrameworkCore;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Interfaces;
using PortalInvestimento.Infra.Data.Context;

namespace PortalInvestimento.Infra.Data.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly ApplicationDbContext _context;
        public AtivoRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Ativo> AlterarAsync(Ativo entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Ativo> CadastrarAsync(Ativo entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Ativo> DeletarAsync(Ativo entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Ativo> ObterPorIdAsync(int? id)
        {
            return await _context.Ativos.FindAsync(id);
        }

        public async Task<IList<Ativo>> ObterTodosAsync()
        {
            return await _context.Ativos.ToListAsync();
        }
    }
}
