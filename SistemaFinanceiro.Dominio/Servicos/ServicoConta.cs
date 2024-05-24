using SistemaFinanceiro.Dominio.DTO;
using SistemaFinanceiro.Dominio.Entidades;
using SistemaFinanceiro.Dominio.Interfaces;

namespace SistemaFinanceiro.Dominio.Servicos
{
    public class ServicoConta : IServicoConta
    {
        private readonly IRepositorioConta _repositorioConta;
        private readonly IRepositorioTransacao _repositorioTransacao;
        private readonly IRepositorioFatura _repositorioFatura;
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicoConta(IRepositorioConta repositorioConta, IRepositorioTransacao repositorioTransacao, IRepositorioFatura repositorioFatura, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioConta = repositorioConta;
            _repositorioTransacao = repositorioTransacao;
            _repositorioFatura = repositorioFatura;
            _repositorioUsuario = repositorioUsuario;
        }

        public object? ObterInformacoesConta(decimal idUsuario)
        {
            var transacoes = _repositorioTransacao.ObterPorIdUsuario(idUsuario);

            if (transacoes != null)
            {
                var conta = _repositorioConta.ObterPorId(transacoes.FirstOrDefault()?.IdConta ?? 0);
                return new { saldo = conta?.Saldo ?? 0, transacoes };
            }

            return null;
        }

        public void CadastrarConta(ContaDTO conta)
        {
            Usuario? usuario = _repositorioUsuario.ObterPorId(conta.IdUsuario ?? 0);
            if (usuario != null)
            {

                _repositorioConta.Adicionar(
                    new Conta()
                    {
                        IdUsuario = usuario.Id,
                        Numero = conta.NumeroConta,
                        Agencia = conta.AgenciaConta,
                        Status = conta.StatusConta,
                        Tipo = conta.TipoConta,
                        Saldo = conta.SaldoInicial,
                        DataAbertura = DateTime.Now
                    }
                );
            }
        }

        public void AlterarConta(Conta contaNova)
        {
            var conta = _repositorioConta.ObterPorId(contaNova.Id ?? 0);

            if (conta != null)
            {
                conta.Numero = contaNova.Numero;
                conta.Agencia = contaNova.Agencia;
                conta.Status = contaNova.Status;
                conta.Tipo = contaNova.Tipo;

                _repositorioConta.Atualizar(conta);
            }
        }

        public List<Conta>? ObterContasPorUsuario(decimal? idUsuario)
        {
            return _repositorioConta.ObterPorIdUsuario(idUsuario ?? 0);
        }

        public void AdicionarFatura(Fatura fatura)
        {
            fatura.Ativo = 1;
            _repositorioFatura.Adicionar(fatura);
        }

        public void AtualizarFatura(Fatura fatura)
        {
            var faturaAntiga = _repositorioFatura.ObterPorId(Convert.ToDecimal(fatura.Id));
            
            if(faturaAntiga != null)
            {
                var statusAntigo = faturaAntiga.Status;
                if(fatura.Status == "PAGA" && faturaAntiga.Status != fatura.Status)
                {
                    var conta = _repositorioConta.ObterPorIdUsuario(Convert.ToDecimal(faturaAntiga.IdUsuario)).FirstOrDefault();
                    conta.Saldo += Convert.ToDecimal(fatura.Subtotal);
                    _repositorioConta.Atualizar(conta);
                }
                faturaAntiga.DataFatura = fatura.DataFatura;
                faturaAntiga.DataVencimento = fatura.DataVencimento;
                faturaAntiga.DescricaoItem = fatura.DescricaoItem;
                faturaAntiga.EnderecoEmitente = fatura.EnderecoEmitente;
                faturaAntiga.PrecoUnitario = fatura.PrecoUnitario;
                faturaAntiga.Quantidade = fatura.Quantidade;
                faturaAntiga.Status = fatura.Status;
                faturaAntiga.Subtotal = fatura.Subtotal;
                faturaAntiga.Ativo = fatura.Ativo;
                _repositorioFatura.Atualizar(faturaAntiga);
            }
        }

        public List<Fatura>? ObterFaturasPorUsuario(decimal idUsuario)
        {
            return _repositorioFatura.ObterPorIdUsuario(idUsuario);
        }
    }
}
