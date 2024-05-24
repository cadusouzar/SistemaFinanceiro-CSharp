using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.DTO
{
    public class TransacaoDTO
    {
        public decimal? IdUsuario { get; set; }
        public string? NumeroConta { get; set; }
        public decimal? Valor { get; set; }
        public string? CpfRecebedor { get; set; }
        public string? NumeroContaDestino { get; set; }
    }
}
