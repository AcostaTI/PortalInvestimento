using PortalInvestimento.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalInvestimento.Domain.Entities
{
    public class Usuario : Entidade
    {
        public Usuario()
        {
            
        }

        //public Usuario(int id, string nome, string email, string senha)
        //{
        //    Id = id;
        //    Nome = nome;
        //    Email = email;
        //    Senha = senha;
        //    PublishDate = DateTime.Now;
        //    LastChanged = DateTime.Now;
        //    Status = 1;
        //}

        //public int TipoPermissao { get; set; }
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Senha { get;  set; }
        public EnTipoAcesso TipoAcesso { get;  set; }
        public ICollection<Portfolio> Portfolios { get; set; }


        public override void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Nome, "Nome precisa ser preenchido.");
            AssertionConcern.AssertArgumentNotEmpty(Email, "E-mail precisa ser preenchido.");
            AssertionConcern.AssertArgumentMatches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", Email, "E-mail invalido!");
        }

    }

    public enum EnTipoAcesso
    {
        Admin = 1,
        Funcionario = 2
    }
}
