using SistemaFinanceiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Interfaces
{
    public interface IServicoUsuario
    {
        Usuario? ObterLogin(string cpf, string senha);
        Usuario? CadastrarUsuario(Usuario usuario);
        void AlterarSenha(decimal idUsuario, string senhaAtual, string senhaNova);
        Usuario? AlterarUsuario(Usuario usuario);
        List<Usuario>? ObterUsuariosPorUsuarioMaster(decimal idUsuarioMaster);
    }
}
