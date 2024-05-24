using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.Dominio.DTO;
using SistemaFinanceiro.Dominio.Entidades;
using SistemaFinanceiro.Dominio.Interfaces;

namespace SistemaFinanceiro.Controllers
{
    [ApiController]
    [Route("conta")]
    public class ContaController : ControllerBase
    {
        private readonly IServicoConta _servicoConta;
        private readonly IServicoTransacao _servicoTransacao;

        public ContaController(IServicoConta servicoConta, IServicoTransacao servicoTransacao)
        {
            _servicoConta = servicoConta;
            _servicoTransacao = servicoTransacao;
        }

        [HttpPost]
        public ActionResult CadastrarConta(ContaDTO contaDTO)
        {
            try
            {
                _servicoConta.CadastrarConta(contaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public ActionResult AtualizarConta(Conta conta)
        {
            try
            {
                _servicoConta.AlterarConta(conta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("lista-contas-usuario")]
        public ActionResult ObterContasUsuario(decimal idUsuario)
        {
            try
            {
                return Ok(_servicoConta.ObterContasPorUsuario(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("dados-conta-transacoes")]
        public ActionResult ObterInformacoesConta(decimal idUsuario)
        {
            try
            {
                return Ok(_servicoConta.ObterInformacoesConta(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("transacao")]
        public ActionResult CadastrarTransacao(TransacaoDTO transacao)
        {
            try
            {
                _servicoTransacao.CadastrarTransacao(transacao);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("fatura")]
        public ActionResult CadastrarFatura(Fatura fatura)
        {
            try
            {
                _servicoConta.AdicionarFatura(fatura);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("fatura")]
        public ActionResult AtualizarFatura(Fatura fatura)
        {
            try
            {
                _servicoConta.AtualizarFatura(fatura);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("fatura")]
        public ActionResult ObterFatura(decimal idUsuario)
        {
            try
            {
                return Ok(_servicoConta.ObterFaturasPorUsuario(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
