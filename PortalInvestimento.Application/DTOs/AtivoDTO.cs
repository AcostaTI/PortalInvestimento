using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalInvestimento.Application.DTOs
{
    public class AtivoDTO
    {
        public enum enTipoInvestimento
        {
            CDB, Acoes, CDI, LDI_LDA, Tesouro, Cripto
        }

        public int Id { get; set; }
        public enTipoInvestimento Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public decimal TaxaADM { get; set; }
    }
}
