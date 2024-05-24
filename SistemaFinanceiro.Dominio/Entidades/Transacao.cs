using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Entidades
{
    public class Transacao
    {
        public decimal? Id { get; set; }
        public decimal? IdConta { get; set; }
        public decimal? Valor { get; set; }
        public string? CpfDestino { get; set; }
        public string? ContaDestino { get; set; }
        public DateTime? DataTransacao { get; set; }
        public decimal? Saldo { get; set; }
    }
}
