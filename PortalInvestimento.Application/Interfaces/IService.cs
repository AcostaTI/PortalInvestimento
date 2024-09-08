using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalInvestimento.Application.Interfaces
{
    public interface IService<T>
    {
        Task<IList<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(int? id);
        Task CadastrarAsync(T entidade);
        Task AlterarAsync(T entidade);
        Task DeletarAsync(int? id);
    }
}
