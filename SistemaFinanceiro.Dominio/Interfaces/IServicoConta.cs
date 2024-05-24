using SistemaFinanceiro.Dominio.DTO;
using SistemaFinanceiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Interfaces
{
    public interface IServicoConta
    {
        object? ObterInformacoesConta(decimal idUsuario);
        void CadastrarConta(ContaDTO conta);
        void AlterarConta(Conta contaNova);
        List<Conta>? ObterContasPorUsuario(decimal? idUsuario);
        void AdicionarFatura(Fatura fatura);
        void AtualizarFatura(Fatura fatura);
        List<Fatura>? ObterFaturasPorUsuario(decimal idUsuario);
    }
}
