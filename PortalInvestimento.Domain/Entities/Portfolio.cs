using PortalInvestimento.Domain.Validation;

namespace PortalInvestimento.Domain.Entities
{
    public class Portfolio : Entidade
    {
        public Portfolio()
        {
            Transacoes = new List<Transacao>();
        }
        public Portfolio(string nome, string descricao, string codigo, int? usuarioId, Usuario usuario)
        {
            Nome = nome;
            Descricao = descricao;
            Codigo = codigo;
            UsuarioId = usuarioId;
            Usuario = usuario;
        }

        public string Nome { get; }
        public string Descricao { get; }
        public string Codigo { get; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get;  set; }
        public ICollection<Transacao> Transacoes { get; set; }

        public override void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Codigo, "Codigo precisa ser preenchido.");
            AssertionConcern.AssertArgumentNotEmpty(Nome, "Nome precisa ser preenchido.");
            AssertionConcern.AssertArgumentNotEmpty(Descricao, "Descricao precisa ser preenchido.");
            
        }
    }
}
