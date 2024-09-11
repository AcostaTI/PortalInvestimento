﻿using PortalInvestimento.Domain.Validation;

namespace PortalInvestimento.Domain.Entities
{
    public class Ativo : Entidade
    {
        public enum enTipoInvestimento
        {
            CDB, Acoes, CDI, LDI_LDA, Tesouro, Cripto
        }
        public enTipoInvestimento Tipo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Codigo { get; private set; }
        public decimal TaxaADM { get; private set; }
        public ICollection<Transacao> Transacoes { get; set; }

        public Ativo()
        {
            
        }

        public Ativo(enTipoInvestimento tipo, string nome, string descricao, string codigo, decimal taxaADM)
        {
            Tipo = tipo;
            Nome = nome;
            Descricao = descricao;
            Codigo = codigo;
            TaxaADM = taxaADM;

            ValidateEntity();

        }

        public override void ValidateEntity()
        {

            AssertionConcern.AssertArgumentNotEmpty(Codigo, "Codigo precisa ser preenchido.");
            AssertionConcern.AssertArgumentLength(Codigo, 50, "Codigo do Investimento precisa ter no maximo 50 caracteres.");

            AssertionConcern.AssertArgumentNotEmpty(Nome, "Nome precisa ser preenchido.");
            AssertionConcern.AssertArgumentLength(Nome, 100, "Nome do Investimento precisa ter no maximo 100 caracteres.");

            AssertionConcern.AssertArgumentNotEquals(Tipo, 0, "Tipo Investimento precisa ser preenchido");

            AssertionConcern.AssertArgumentRange((double)TaxaADM, 0.1, 10, "Taxa ADM precisa estar entre 0.1 e 10.");

        }

    }
}
