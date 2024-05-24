using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Entidades
{
    public class Fatura
    {
        public int? Id { get; set; }
        public string? DataFatura { get; set; }
        public string? DataVencimento { get; set; }
        public string? EnderecoEmitente { get; set; }
        public int? IdUsuario { get; set; }
        public string? DescricaoItem { get; set; }
        public string? Quantidade { get; set; }
        public string? PrecoUnitario { get; set; }
        public string? Subtotal { get; set; }
        public string? Status { get; set; }
        public int? Ativo {  get; set; }
    }
}
