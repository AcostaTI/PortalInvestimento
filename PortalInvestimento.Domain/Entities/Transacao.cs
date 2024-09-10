using PortalInvestimento.Domain.Validation;

namespace PortalInvestimento.Domain.Entities
{
    public class Transacao : Entidade
    {
        public Transacao()
        {

        }
        public Transacao(int quantidade, decimal preco, DateTime dataTransacao, int portfolioId , int ativoId)
        {
            Quantidade = quantidade;
            Preco = preco;
            Total = quantidade * preco;
            DataTransacao = dataTransacao;
            PortfolioId = portfolioId;
            AtivoId = ativoId;

            ValidateEntity();
        }

        public Transacao(int id, int quantidade, decimal preco, DateTime dataTransacao, int portfolioId, int ativoId, string operacao)
        {
            Id = id;
            Quantidade = quantidade;
            Preco = preco;
            Total = quantidade * preco;
            DataTransacao = DateTime.Now;
            Operacao = operacao; 
            PortfolioId = portfolioId;
            AtivoId = ativoId;

            ValidateEntity();
        }

        public int Quantidade { get; private set; }
        public decimal Preco { get; private set; }
        public decimal Total { get; private set; }
        public DateTime DataTransacao { get; private set; }
        public string Operacao { get; private set; }
        public int PortfolioId { get;  set; }
        public Portfolio Portfolio { get;  set; }
        public int AtivoId { get;  set; }
        public Ativo Ativo { get;  set; }

        public override void ValidateEntity()
        {
            AssertionConcern.AssertArgumentRange((double)Preco, 0.1, 1000000, "Deve ser entre 0.1 e 1000000");
            AssertionConcern.AssertArgumentLength(Operacao, 1, "Não deve ser maior que 1 caractere");
        }
    }
}
