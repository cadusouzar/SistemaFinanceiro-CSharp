using SistemaFinanceiro.Dominio.DTO;
using SistemaFinanceiro.Dominio.Entidades;
using SistemaFinanceiro.Dominio.Interfaces;

namespace SistemaFinanceiro.Dominio.Servicos
{
    public class ServicoTransacao : IServicoTransacao
    {
        private readonly IRepositorioTransacao _repositorioTransacao;
        private readonly IRepositorioConta _repositorioConta;

        public ServicoTransacao(IRepositorioTransacao repositorioTransacao, IRepositorioConta repositorioConta)
        {
            _repositorioTransacao = repositorioTransacao;
            _repositorioConta = repositorioConta;
        }

        public void CadastrarTransacao(TransacaoDTO transacao)
        {
            var conta = _repositorioConta.ObterPorIdUsuario(transacao.IdUsuario ?? 0)?.Where(p => p.Numero == transacao.NumeroConta).FirstOrDefault();

            if (conta != null)
            {
                _repositorioTransacao.Adicionar(
                    new Transacao()
                    {
                        IdConta = conta.Id,
                        Valor = transacao.Valor,
                        Saldo = conta.Saldo - transacao.Valor,
                        DataTransacao = DateTime.Now,
                        ContaDestino = transacao.NumeroContaDestino,
                        CpfDestino = transacao.CpfRecebedor
                    });

                conta.Saldo -= transacao.Valor;
                _repositorioConta.Atualizar(conta);

                var contaDestino = _repositorioConta.ObterPorNumero(transacao.NumeroContaDestino);

                if (contaDestino != null)
                {
                    contaDestino.Saldo += transacao.Valor;
                    _repositorioConta.Atualizar(contaDestino);
                }
            }
        }


    }
}
