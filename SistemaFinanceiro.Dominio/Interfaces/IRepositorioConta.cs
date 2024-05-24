using SistemaFinanceiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Interfaces
{
    public interface IRepositorioConta
    {
        void Adicionar(Conta conta);
        void Atualizar(Conta conta);
        Conta? ObterPorId(decimal id);
        List<Conta>? ObterPorIdUsuario(decimal id);
        Conta? ObterPorNumero(string? numero);
    }
}
