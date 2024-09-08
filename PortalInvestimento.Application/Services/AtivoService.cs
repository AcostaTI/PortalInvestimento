using AutoMapper;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Application.Interfaces;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Interfaces;

namespace PortalInvestimento.Application.Services
{
    public class AtivoService : IAtivoService
    {
        private readonly IAtivoRepository _ativoRepository;
        private readonly IMapper _mapper;

        public AtivoService(IAtivoRepository ativoRepository, IMapper mapper)
        {
            _ativoRepository = ativoRepository;
            _mapper = mapper;
        }
        public async Task AlterarAsync(AtivoDTO entidade)
        {
            var ativo = _mapper.Map<Ativo>(entidade);
            await _ativoRepository.AlterarAsync(ativo);
        }

        public async Task CadastrarAsync(AtivoDTO entidade)
        {
            var ativo = _mapper.Map<Ativo>(entidade);
            await _ativoRepository.CadastrarAsync(ativo);
        }

        public async Task DeletarAsync(int? id)
        {
            var ativo = _ativoRepository.ObterPorIdAsync(id).Result;
            await _ativoRepository.DeletarAsync(ativo);

        }

        public async Task<AtivoDTO> ObterPorIdAsync(int? id)
        {
            var ativo = await _ativoRepository.ObterPorIdAsync(id);
            return _mapper.Map<AtivoDTO>(ativo);
        }

        public async Task<IList<AtivoDTO>> ObterTodosAsync()
        {
            var ativos = await _ativoRepository.ObterTodosAsync();
            return _mapper.Map<IList<AtivoDTO>>(ativos);
        }

    }
}
