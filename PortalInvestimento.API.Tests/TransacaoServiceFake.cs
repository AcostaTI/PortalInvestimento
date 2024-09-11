using AutoMapper;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;
using PortalInvestimento.Domain.Entities;

namespace PortalInvestimento.API.Tests
{
    public class TransacaoServiceFake : ITransacaoService
    {
        private readonly List<TransacaoDTO> _transacao;
        public TransacaoServiceFake()
        {
            _transacao = new List<TransacaoDTO>
            {
                new TransacaoDTO(){ Id = 1, AtivoId = 1, PortfolioId = 1,Preco = 150.00M, Operacao = "A", Quantidade = 1 },
                new TransacaoDTO(){ Id = 2, AtivoId = 1, PortfolioId = 2,Preco = 200.00M, Operacao = "A", Quantidade = 2 },
                new TransacaoDTO(){ Id = 3, AtivoId = 2, PortfolioId = 2,Preco = 100.00M, Operacao = "R", Quantidade = 3 },
                new TransacaoDTO(){ Id = 4, AtivoId = 3, PortfolioId = 1,Preco = 75.25M, Operacao = "A", Quantidade = 5 },
                new TransacaoDTO(){ Id = 5, AtivoId = 4, PortfolioId = 1,Preco = 25.00M, Operacao = "R", Quantidade = 2 },
                new TransacaoDTO(){ Id = 6, AtivoId = 3, PortfolioId = 3,Preco = 10.00M, Operacao = "R", Quantidade = 2 },

            };
        }
        public Task AlterarAsync(TransacaoDTO entidade)
        {
            throw new NotImplementedException();
        }

        public async Task CadastrarAsync(TransacaoDTO entidade)
        {
            entidade.Id = GeraId();
            _transacao.Add(entidade);
        }

        public async Task DeletarAsync(int? id)
        {
            var transacao = _transacao.Where(t => t.Id == id).FirstOrDefault();
            _transacao.Remove(transacao);
        }

        public async Task<TransacaoDTO> ObterPorIdAsync(int? id)
        {
            return _transacao.Where(t => t.Id == id).FirstOrDefault();
        }

        public async Task<IList<TransacaoDTO>> ObterTodosAsync()
        {
            return _transacao;
        }

        public Task<IList<TransacaoDTO>> ObterTransacaoPorPortfolioId(int portfolioId)
        {
            throw new NotImplementedException();
        }

        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
