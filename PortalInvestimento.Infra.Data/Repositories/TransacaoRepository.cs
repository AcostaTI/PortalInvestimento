using Microsoft.EntityFrameworkCore;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Interfaces;
using PortalInvestimento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (id > 0)
                return await _context.Transacoes.FindAsync(id);

            return null;
        }

        public async Task<IList<Transacao>> ObterTodosAsync()
        {
            return await _context.Transacoes.ToListAsync();
        }
    }
}
