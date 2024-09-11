using FluentAssertions;
using PortalInvestimento.Domain.Entities;
using PortalInvestimento.Domain.Validation;

namespace PortalInvestimento.Domain.Tests
{
    public class TransacaoUnitTest
    {
        [Fact]
        public void CreateTransacao_ParametrosValidos_RetornoValido()
        {
            Action action = () => new Transacao(1,2, 1.5M, DateTime.Now, 1, 1, "A");

            action.Should().NotThrow<DomainException>();
        }

        [Fact]
        public void CreateTransacao_OperacaoComMaisDeUmcaractere_RetornoExcception()
        {
            Action action = () => new Transacao(1, 2, 1.5M, DateTime.Now, 1, 1, "AR");

            action.Should().Throw<DomainException>().WithMessage("Não deve ser maior que 1 caractere.");
        }

        //[Fact]
        //public void CreateTransacao_OperacaoComMaisDeUmcaractere_RetornoExcception()
        //{
        //    Action action = () => new Transacao(1, 2, 1.5M, DateTime.Now, 1, 1, "A");

        //    action.
        //}

    }
}
