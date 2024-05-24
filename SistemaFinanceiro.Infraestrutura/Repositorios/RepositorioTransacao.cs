using Microsoft.Extensions.Configuration;
using SistemaFinanceiro.Dominio.Entidades;
using SistemaFinanceiro.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Infraestrutura.Repositorios
{
    public class RepositorioTransacao : RepositorioBase, IRepositorioTransacao
    {
        public RepositorioTransacao(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(Transacao transacao)
        {
            string script = $@"INSERT INTO SISTEMA_FINANCEIRO.TRANSACAO 
                                    (CD_CONTA_TRANSACAO,VL_TRANSACAO,NM_CPF_DESTINO_TRANSACAO,NM_CONTA_DESTINO_TRANSACAO, DT_TRANSACAO, VL_SALDO_CONTA_TRANSACAO) 
                               VALUES (@IdConta, @Valor, @CpfDestino, @ContaDestino, @DataTransacao, @Saldo)";

            Executar<Transacao>(script, transacao);
        }

        public void Atualizar(Transacao transacao)
        {
            string script = $@"UPDATE SISTEMA_FINANCEIRO.TRANSACAO SET
                               CD_CONTA_TRANSACAO = @IdConta,
                               VL_TRANSACAO = @Valor,
                               NM_CPF_DESTINO_TRANSACAO = @CpfDestino,
                               NM_CONTA_DESTINO_TRANSACAO = @ContaDestino,
                               DT_TRANSACAO = @DataTransacao,
                               VL_SALDO_CONTA_TRANSACAO = @Saldo
                               WHERE CD_TRANSACAO = @Id";

            Executar<Transacao>(script, transacao);
        }

        public Transacao? ObterPorId(decimal id)
        {
            string script = $@"SELECT
                                    T.CD_TRANSACAO Id,
                                    T.CD_CONTA_TRANSACAO IdConta,
                                    T.VL_TRANSACAO Valor,
                                    T.NM_CPF_DESTINO_TRANSACAO CpfDestino,
                                    T.NM_CONTA_DESTINO_TRANSACAO ContaDestino,
                                    T.DT_TRANSACAO DataTransacao,
                                    T.VL_SALDO_CONTA_TRANSACAO Saldo
                               FROM SISTEMA_FINANCEIRO.TRANSACAO T
                               WHERE T.CD_TRANSACAO = @Id";

            return Obter<Transacao>(script, new { Id = id });
        }

        public List<Transacao>? ObterPorIdConta(decimal? idConta)
        {
            string script = $@"SELECT
                                    T.CD_TRANSACAO Id,
                                    T.CD_CONTA_TRANSACAO IdConta,
                                    T.VL_TRANSACAO Valor,
                                    T.NM_CPF_DESTINO_TRANSACAO CpfDestino,
                                    T.NM_CONTA_DESTINO_TRANSACAO ContaDestino,
                                    T.DT_TRANSACAO DataTransacao,
                                    T.VL_SALDO_CONTA_TRANSACAO Saldo
                               FROM SISTEMA_FINANCEIRO.TRANSACAO T
                               WHERE T.CD_CONTA_TRANSACAO = @IdConta";

            return ObterLista<Transacao>(script, new { IdConta = idConta });
        }

        public List<Transacao>? ObterPorIdUsuario(decimal? id)
        {
            string script = $@"SELECT
                                    T.CD_TRANSACAO Id,
                                    T.CD_CONTA_TRANSACAO IdConta,
                                    T.VL_TRANSACAO Valor,
                                    T.NM_CPF_DESTINO_TRANSACAO CpfDestino,
                                    T.NM_CONTA_DESTINO_TRANSACAO ContaDestino,
                                    T.DT_TRANSACAO DataTransacao,
                                    T.VL_SALDO_CONTA_TRANSACAO Saldo
                               FROM SISTEMA_FINANCEIRO.CONTA C
                                    INNER JOIN SISTEMA_FINANCEIRO.TRANSACAO T ON (T.CD_CONTA_TRANSACAO = C.CD_CONTA OR C.NM_NUMERO_CONTA = T.NM_CONTA_DESTINO_TRANSACAO)
                               WHERE C.CD_USUARIO_CONTA = @Id";

            return ObterLista<Transacao>(script, new { Id = id });
        }
    }
}
