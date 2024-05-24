using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Entidades
{
    public class Usuario
    {
        public decimal? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Cpf { get; set; }
        public string? Cargo { get; set; }
        public decimal? IdMaster { get; set; }
    }
}
