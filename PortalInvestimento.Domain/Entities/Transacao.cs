using PortalInvestimento.Domain.Validation;

namespace PortalInvestimento.Domain.Entities
{
    public class Transacao : Entidade
    {
        public Transacao(int quantidade, decimal preco, DateTime dataTransacao, int portfolioId , int ativoId)
        {
            Quantidade = quantidade;
            Preco = preco;
            DataTransacao = dataTransacao;
            PortfolioId = portfolioId;
            AtivoId = ativoId;

            ValidateEntity();
        }

        public int Quantidade { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime DataTransacao { get; private set; }
        public int PortfolioId { get;  set; }
        public Portfolio Portfolio { get;  set; }
        public int AtivoId { get;  set; }
        public Ativo Ativo { get;  set; }

        public override void ValidateEntity()
        {
            AssertionConcern.AssertArgumentRange((double)Preco, 0.1, 1000000, "Deve ser entre 0.1 e 1000000");
        }
    }
}
