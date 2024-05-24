using SistemaFinanceiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Interfaces
{
    public interface IRepositorioTransacao
    {
        void Adicionar(Transacao transacao);
        void Atualizar(Transacao transacao);
        Transacao? ObterPorId(decimal id);
        List<Transacao>? ObterPorIdConta(decimal? idConta);
        List<Transacao>? ObterPorIdUsuario(decimal? id);
    }
}
