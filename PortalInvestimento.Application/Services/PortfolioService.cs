using AutoMapper;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Interfaces;

namespace PortalInvestimento.Application.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public PortfolioService(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task AlterarAsync(PortfolioDTO entidade)
        {
            var portfolio = _mapper.Map<Portfolio>(entidade);
            await _portfolioRepository.AlterarAsync(portfolio);
        }

        public async Task CadastrarAsync(PortfolioDTO entidade)
        {
            var portfolio = _mapper.Map<Portfolio>(entidade);
            await _portfolioRepository.CadastrarAsync(portfolio);
        }

        public async Task DeletarAsync(int? id)
        {
            var portfolio = _portfolioRepository.ObterPorIdAsync(id).Result;
            await _portfolioRepository.DeletarAsync(portfolio);
        }

        public async Task<PortfolioDTO> ObterPorIdAsync(int? id)
        {
            var portfolio = await _portfolioRepository.ObterPorIdAsync(id);
            return _mapper.Map<PortfolioDTO>(portfolio);
        }

        public async Task<IList<PortfolioDTO>> ObterTodosAsync()
        {
            var portfolio = await _portfolioRepository.ObterTodosAsync();
            return _mapper.Map<IList<PortfolioDTO>>(portfolio);
        }
    }
}
