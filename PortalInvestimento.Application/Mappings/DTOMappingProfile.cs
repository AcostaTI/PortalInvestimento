using AutoMapper;
using PortalInvestimento.Application.DTOs;
using PortalInvestimento.Domain.Entities;

namespace PortalInvestimento.Application.Mappings
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile() 
        {
            CreateMap<AtivoDTO, Ativo>().ReverseMap();
            CreateMap<TransacaoDTO, Transacao>().ReverseMap();
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            CreateMap<PortfolioDTO, Portfolio>().ReverseMap();
        }
    }
}
