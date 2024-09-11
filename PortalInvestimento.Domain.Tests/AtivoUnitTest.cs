using FluentAssertions;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Validation;

namespace PortalInvestimento.Domain.Tests
{
    public class AtivoUnitTest
    {
        [Fact]
        public void CreateAtivo_ParametrosValidos_RetornoValido()
        {
            Action action = () => new Ativo(Ativo.enTipoInvestimento.Acoes, "Ativo1", "Descrição Ativo", "A1", 1);

            action.Should().NotThrow<DomainException>();
        }

        [Fact]
        public void CreateTransacao_TaxaAdmIgualZero_RetornoExcception()
        {
            Action action = () => new Ativo(Ativo.enTipoInvestimento.Acoes, "Ativo1", "Descrição Ativo", "A1", 0);

            action.Should().Throw<DomainException>().WithMessage("Taxa ADM precisa estar entre 0.1 e 10.");

        }

        [Fact]
        public void CreateTransacao_CodigoNotEmpty_RetornoExcception()
        {
            Action action = () => new Ativo(Ativo.enTipoInvestimento.Acoes, "Ativo1", "Descrição Ativo", "", 0);

            action.Should().Throw<DomainException>().WithMessage("Codigo precisa ser preenchido.");

        }

        [Fact]
        public void CreateTransacao_CodigoMaisDeCiquentaCaracteres_RetornoExcception()
        {
            Action action = () => new Ativo(Ativo.enTipoInvestimento.Acoes, "Ativo1", "Descrição Ativo", "aqui tem mais de cinquenta caracteres vai da errado.", 1);

            action.Should().Throw<DomainException>().WithMessage("Codigo do Investimento precisa ter no maximo 50 caracteres.");

        }

        [Fact]
        public void CreateTransacao_NomeNotEmpty_RetornoExcception()
        {
            Action action = () => new Ativo(Ativo.enTipoInvestimento.Acoes, "", "Descrição Ativo", "A1", 0);

            action.Should().Throw<DomainException>().WithMessage("Nome precisa ser preenchido.");

        }

        [Fact]
        public void CreateTransacao_NomeMaisDeCiquentaCaracteres_RetornoExcception()
        {
            Action action = () => new Ativo(Ativo.enTipoInvestimento.Acoes, "aqui tem mais de cem caracteres vai da errado. alteração para build do pipeline e verificar a compilação dos testes unitarios da aplicação............", "Descrição Ativo", "Test", 1);

            action.Should().Throw<DomainException>().WithMessage("Nome do Investimento precisa ter no maximo 100 caracteres.");

        }
    }
}
