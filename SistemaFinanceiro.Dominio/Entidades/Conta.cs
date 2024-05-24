using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Entidades
{
    public class Conta
    {
        public decimal? Id { get; set; }
        public decimal? IdUsuario { get; set; }
        public string? Numero { get; set; }
        public DateTime? DataAbertura { get; set; }
        public string? Tipo { get; set; }
        public string? Agencia { get; set; }
        public string? Status { get; set; }
        public decimal? Saldo { get; set; }
    }
}
