using PortalInvestimento.Domain.Entities;

namespace PortalInvestimento.Application.DTOs
{
    public class TransacaoDTO
    {
        public int Id { get;  set; }
        public int Quantidade { get;  set; }
        public decimal Preco { get;  set; }
        public decimal Total { get;  private set; }
        public DateTime DataTransacao { get;  private set; }
        public string Operacao { get; set; }
        public int PortfolioId { get; set; }
        public int AtivoId { get; set; }

    }
}
