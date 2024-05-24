using SistemaFinanceiro.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Interfaces
{
    public interface IServicoTransacao
    {
        void CadastrarTransacao(TransacaoDTO transacao);
    }
}
