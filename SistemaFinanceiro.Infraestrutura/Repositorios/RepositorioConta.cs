using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SistemaFinanceiro.Dominio.Entidades;
using SistemaFinanceiro.Dominio.Interfaces;

namespace SistemaFinanceiro.Infraestrutura.Repositorios
{
    public class RepositorioConta : RepositorioBase, IRepositorioConta
    {
        public RepositorioConta(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(Conta conta)
        {
            string script = $@"INSERT INTO SISTEMA_FINANCEIRO.CONTA 
                                    (CD_USUARIO_CONTA,NM_NUMERO_CONTA,DT_ABERTURA_CONTA,NM_TIPO_CONTA,NM_AGENCIA_CONTA,DS_STATUS_CONTA, VL_SALDO_CONTA) 
                               VALUES (@IdUsuario, @Numero, @DataAbertura, @Tipo, @Agencia, @Status, @Saldo)";

            Executar<Conta>(script, conta);
        }

        public void Atualizar(Conta conta)
        {
            string script = $@"UPDATE SISTEMA_FINANCEIRO.CONTA SET
                               CD_USUARIO_CONTA = @IdUsuario,
                               NM_NUMERO_CONTA = @Numero,
                               DT_ABERTURA_CONTA = @DataAbertura,
                               NM_TIPO_CONTA = @Tipo,
                               NM_AGENCIA_CONTA = @Agencia,
                               DS_STATUS_CONTA = @Status,
                               VL_SALDO_CONTA = @Saldo
                               WHERE CD_CONTA = @Id";

            Executar<Conta>(script, conta);
        }

        public Conta? ObterPorId(decimal id)
        {
            string script = $@"SELECT
                                    C.CD_CONTA Id,
                                    C.CD_USUARIO_CONTA IdUsuario,
                                    C.NM_NUMERO_CONTA Numero,
                                    C.DT_ABERTURA_CONTA DataAbertura,
                                    C.NM_TIPO_CONTA Tipo,
                                    C.NM_AGENCIA_CONTA Agencia,
                                    C.DS_STATUS_CONTA Status,
                                    C.VL_SALDO_CONTA Saldo
                               FROM SISTEMA_FINANCEIRO.CONTA C
                               WHERE C.CD_CONTA = @Id";

            return Obter<Conta>(script, new { Id = id });
        }

        public List<Conta>? ObterPorIdUsuario(decimal id)
        {
            string script = $@"SELECT
                                    C.CD_CONTA Id,
                                    C.CD_USUARIO_CONTA IdUsuario,
                                    C.NM_NUMERO_CONTA Numero,
                                    C.DT_ABERTURA_CONTA DataAbertura,
                                    C.NM_TIPO_CONTA Tipo,
                                    C.NM_AGENCIA_CONTA Agencia,
                                    C.DS_STATUS_CONTA Status,
                                    C.VL_SALDO_CONTA Saldo
                               FROM SISTEMA_FINANCEIRO.CONTA C
                               WHERE C.CD_USUARIO_CONTA = @Id";

            return ObterLista<Conta>(script, new { Id = id });
        }

        public Conta? ObterPorNumero(string? numero)
        {
            string script = $@"SELECT
                                    C.CD_CONTA Id,
                                    C.CD_USUARIO_CONTA IdUsuario,
                                    C.NM_NUMERO_CONTA Numero,
                                    C.DT_ABERTURA_CONTA DataAbertura,
                                    C.NM_TIPO_CONTA Tipo,
                                    C.NM_AGENCIA_CONTA Agencia,
                                    C.DS_STATUS_CONTA Status,
                                    C.VL_SALDO_CONTA Saldo
                               FROM SISTEMA_FINANCEIRO.CONTA C
                               WHERE C.NM_NUMERO_CONTA = @Numero";

            return Obter<Conta>(script, new { Numero = numero });
        }
    }
}
