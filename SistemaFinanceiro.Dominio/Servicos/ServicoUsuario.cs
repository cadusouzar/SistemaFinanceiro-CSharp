using SistemaFinanceiro.Dominio.Entidades;
using SistemaFinanceiro.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public Usuario? ObterLogin(string cpf, string senha)
        {
            var usuario = _repositorioUsuario.ObterPorCpfSenha(cpf, senha);
            return usuario;
        }

        public Usuario? CadastrarUsuario(Usuario usuario)
        {
            _repositorioUsuario.Adicionar(usuario);
            var usuarioNovo = _repositorioUsuario.ObterPorCpfSenha(usuario.Cpf ?? "", usuario.Senha ?? "");

            if (usuario.IdMaster != null)
                _repositorioUsuario.AdicionarAmrUsuario(usuarioNovo?.Id ?? 0, usuario.IdMaster ?? 0);

            return usuarioNovo;
        }

        public Usuario? AlterarUsuario(Usuario usuario)
        {
            Usuario? usuarioNovo = _repositorioUsuario.ObterPorId(usuario.Id ?? 0);

            if (usuarioNovo != null)
            {
                usuarioNovo.Cargo = usuario.Cargo ?? usuarioNovo.Cargo;
                usuarioNovo.Email = usuario.Email ?? usuarioNovo.Email;
                usuarioNovo.Cpf = usuarioNovo.Cpf ?? usuarioNovo.Cpf;
                usuarioNovo.Nome = usuarioNovo.Nome ?? usuarioNovo.Nome;
            }

            return usuarioNovo;
        }

        public List<Usuario>? ObterUsuariosPorUsuarioMaster(decimal idUsuarioMaster)
        {
            var list = _repositorioUsuario.ObterListaPorUsuarioMaster(idUsuarioMaster);
            return list;
        }

        public void AlterarSenha(decimal idUsuario, string senhaAtual, string senhaNova)
        {
            var usuario = _repositorioUsuario.ObterPorId(idUsuario);

            if (usuario?.Senha != null && usuario.Senha.Equals(senhaAtual))
            {
                usuario.Senha = senhaNova;
                _repositorioUsuario.Atualizar(usuario);
            }                
        }
    }
}
