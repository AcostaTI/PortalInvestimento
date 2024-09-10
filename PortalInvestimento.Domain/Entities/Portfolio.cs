using PortalInvestimento.Domain.Validation;

namespace PortalInvestimento.Domain.Entities
{
    public class Portfolio : Entidade
    {
        public Portfolio()
        {
            
        }
        //public Portfolio(string nome, string descricao, string codigo) 
        //{

        //    Nome = nome;
        //    Descricao = descricao;
        //    Codigo = codigo;

        //    //ValidateEntity();
        //}

        //public Portfolio(int id, string nome, string descricao, string codigo)
        //{
        //    Id = id;
        //    Nome = nome;
        //    Descricao = descricao;
        //    Codigo = codigo;

        //    //ValidateEntity();
        //}

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Codigo { get; private set; }
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
