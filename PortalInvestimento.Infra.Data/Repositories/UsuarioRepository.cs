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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> AlterarAsync(Usuario entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Usuario> CadastrarAsync(Usuario entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Usuario> DeletarAsync(Usuario entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<Usuario> ObterPorIdAsync(int? id)
        {
            if (id > 0)
                return await _context.Usuarios.FindAsync(id);

            return null;
        }

        public async Task<Usuario> ObterPorNomeUsuarioESenhaAsync(string email, string senha)
        {
            return await _context.Usuarios.Where(u => u.Email == email && u.Senha == senha).SingleOrDefaultAsync();
        }

        public async Task<IList<Usuario>> ObterTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
