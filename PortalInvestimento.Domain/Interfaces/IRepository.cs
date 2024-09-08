using PortalInvestimento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalInvestimento.Domain.Interfaces
{
    public interface IRepository<T> where T : Entidade
    {
        Task<IList<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(int? id);
        Task<T> CadastrarAsync(T entidade);
        Task<T> AlterarAsync(T entidade);
        Task<T> DeletarAsync(T entidade);
    }
}
