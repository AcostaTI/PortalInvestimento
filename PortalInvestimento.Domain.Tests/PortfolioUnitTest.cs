
using System.Runtime.ConstrainedExecution;
using FluentAssertions;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Validation;

namespace PortalInvestimento.Domain.Tests
{
    public class PortfolioUnitTest
    {
        //Usuario usuario = new Usuario() 
        //{
        //    Nome = "Usuario Teste",
        //    Email = "Email@Teste.com",
        //    Senha = "SenhaTeste",
        //    TipoAcesso = EnTipoAcesso.Admin
        //};
        //[Fact]
        //public void CreatePortfolio_ParametrosValidos_RetornoValido()
        //{
        //    Action action = () => new Portfolio("Portfolio1", "Descricao do Portfolio", "P1", 1, usuario);
        //    action.Should().NotThrow<DomainException>();
        //}
        //[Fact]
        //public void CreatePortfolio_CodigoNotEmpty_RetornoExcception()
        //{
        //    Action action = () => new Portfolio("", "Descricao do Portfolio", "P1", 0, usuario);
        //    action.Should().Throw<DomainException>().WithMessage("Nome precisa ser preenchido.");
        //}
        //[Fact]
        //public void CreatePortfolio_NomeNotEmpty_RetornoExcception()
        //{
        //    Action action = () => new Portfolio("Portfolio1", "Descricao do Portfolio", "", 0, usuario);
        //    action.Should().Throw<DomainException>().WithMessage("Codigo precisa ser preenchido."); 
        //}
        //[Fact]
        //public void CreatePortfolio_DescricaoNotEmpty_RetornoExcception()
        //{
        //    Action action = () => new Portfolio("Portfolio1", "", "P1", 0, usuario);
        //    action.Should().Throw<DomainException>().WithMessage("Descricao precisa ser preenchido.");
        //}
    }
}
