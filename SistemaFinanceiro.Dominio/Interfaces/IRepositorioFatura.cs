using SistemaFinanceiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Interfaces
{
    public interface IRepositorioFatura
    {
        void Adicionar(Fatura fatura);
        void Atualizar(Fatura fatura);
        Fatura? ObterPorId(decimal id);
        List<Fatura>? ObterPorIdUsuario(decimal? id);
    }
}
