using PortalInvestimento.Domain.Entities;

namespace PortalInvestimento.Application.DTOs
{
    public class PortfolioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public int? UsuarioId { get; set; }

    }
}
