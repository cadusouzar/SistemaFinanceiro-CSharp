using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SistemaFinanceiro.Dominio.DTO
{
    public class ContaDTO
    {
        public decimal? IdUsuario { get; set; }
        public string? NumeroConta { get; set; }
        public string? TipoConta { get; set; }
        public string? AgenciaConta { get; set; }
        public string? StatusConta { get; set; }
        public decimal? SaldoInicial { get; set; }
    }
}
