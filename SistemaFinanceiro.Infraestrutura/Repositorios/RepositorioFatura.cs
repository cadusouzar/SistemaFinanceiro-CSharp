using Microsoft.Extensions.Configuration;
using SistemaFinanceiro.Dominio.Entidades;
using SistemaFinanceiro.Dominio.Interfaces;

namespace SistemaFinanceiro.Infraestrutura.Repositorios
{
    public class RepositorioFatura : RepositorioBase, IRepositorioFatura
    {
        public RepositorioFatura(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(Fatura fatura)
        {
            string script = $@"INSERT INTO SISTEMA_FINANCEIRO.FATURA 
                                    (DT_FATURA,DT_VENCIMENTO,DS_ENDERECO_EMITENTE,DS_ITEM, NM_QUANTIDADE, VL_PRECO_UNITARIO,DS_SUBTOTAL,DS_STATUS,FL_ATIVO,CD_USUARIO) 
                               VALUES (@DataFatura,@DataVencimento,@EnderecoEmitente,@DescricaoItem,@Quantidade,@PrecoUnitario,@Subtotal,@Status,@Ativo,@IdUsuario)";

            Executar<Fatura>(script, fatura);
        }

        public void Atualizar(Fatura fatura)
        {
            string script = $@"UPDATE SISTEMA_FINANCEIRO.FATURA SET
                               DT_FATURA = @DataFatura,
                               DT_VENCIMENTO = @DataVencimento,
                               DS_ENDERECO_EMITENTE = @EnderecoEmitente,
                               DS_ITEM = @DescricaoItem,
                               NM_QUANTIDADE = @Quantidade,
                               VL_PRECO_UNITARIO = @PrecoUnitario,
                               DS_SUBTOTAL = @Subtotal,
                               DS_STATUS = @Status,
                               FL_ATIVO = @Ativo,
                               CD_USUARIO = @IdUsuario
                               WHERE CD_FATURA = @Id";

            Executar<Fatura>(script, fatura);
        }

        public Fatura? ObterPorId(decimal id)
        {
            string script = $@"SELECT
                                    F.CD_FATURA Id,
                                    F.DT_FATURA DataFatura,
                                    F.DT_VENCIMENTO DataVencimento,
                                    F.DS_ENDERECO_EMITENTE EnderecoEmitente,
                                    F.DS_ITEM DescricaoItem,
                                    F.NM_QUANTIDADE Quantidade,
                                    F.VL_PRECO_UNITARIO PrecoUnitario,
                                    F.DS_SUBTOTAL Subtotal,
                                    F.DS_STATUS Status,
                                    F.FL_ATIVO Ativo,
                                    F.CD_USUARIO IdUsuario
                               FROM SISTEMA_FINANCEIRO.FATURA F
                               WHERE F.CD_FATURA = @Id";

            return Obter<Fatura>(script, new { Id = id });
        }

        public List<Fatura>? ObterPorIdUsuario(decimal? id)
        {
            string script = $@"SELECT
                                    F.CD_FATURA Id,
                                    F.DT_FATURA DataFatura,
                                    F.DT_VENCIMENTO DataVencimento,
                                    F.DS_ENDERECO_EMITENTE EnderecoEmitente,
                                    F.DS_ITEM DescricaoItem,
                                    F.NM_QUANTIDADE Quantidade,
                                    F.VL_PRECO_UNITARIO PrecoUnitario,
                                    F.DS_SUBTOTAL Subtotal,
                                    F.DS_STATUS Status,
                                    F.FL_ATIVO Ativo,
                                    F.CD_USUARIO IdUsuario
                               FROM SISTEMA_FINANCEIRO.FATURA F
                               WHERE F.CD_USUARIO = @Id";

            return ObterLista<Fatura>(script, new { Id = id });
        }
    }
}
