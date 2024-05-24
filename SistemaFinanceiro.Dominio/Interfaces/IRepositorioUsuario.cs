using SistemaFinanceiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Dominio.Interfaces
{
    public interface IRepositorioUsuario
    {
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario? ObterPorId(decimal id);
        Usuario? ObterPorCpfSenha(string cpf, string senha);
        void AdicionarAmrUsuario(decimal idUsuario, decimal idUsuarioMaster);
        List<Usuario>? ObterListaPorUsuarioMaster(decimal idUsuario);
    }
}
