using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.Dominio.Entidades;
using SistemaFinanceiro.Dominio.Interfaces;

namespace SistemaFinanceiro.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicoUsuario _servicoUsuario;

        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        [HttpGet("login")]
        public ActionResult Login(string cpf, string senha)
        {
            try
            {
                var usuario = _servicoUsuario.ObterLogin(cpf, senha);

                if (usuario != null)
                    return Ok(new { usuario.Id, usuario.Nome, usuario.Cpf, usuario.Cargo });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("novo-usuario")]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {
            try { 
                var usuarioNovo = _servicoUsuario.CadastrarUsuario(usuario); 
            
                if (usuarioNovo != null)
                    return Ok(new { usuarioNovo.Id, usuarioNovo.Nome, usuarioNovo.Cpf });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public ActionResult AlterarUsuario(Usuario usuario)
        {
            try
            {
                return Ok(_servicoUsuario.AlterarUsuario(usuario));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("lista-usuarios")]
        public ActionResult ObterLista(decimal idUsuario)
        {
            try
            {
                return Ok(_servicoUsuario.ObterUsuariosPorUsuarioMaster(idUsuario));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("nova-senha")]
        public ActionResult AlterarSenha(decimal idUsuario, string senhaAtual, string novaSenha)
        {
            try { 
                _servicoUsuario.AlterarSenha(idUsuario, senhaAtual, novaSenha);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
