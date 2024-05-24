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
    public class RepositorioUsuario : RepositorioBase, IRepositorioUsuario
    {
        public RepositorioUsuario(IConfiguration configuration) : base(configuration)
        {
        }

        public void Adicionar(Usuario usuario)
        {
            string script = $@"INSERT INTO SISTEMA_FINANCEIRO.USUARIO 
                                    (NM_USUARIO,DS_EMAIL_USUARIO,NM_SENHA_USUARIO,CD_CPF_USUARIO,NM_CARGO_USUARIO) 
                               VALUES (@Nome, @Email, @Senha, @Cpf, @Cargo)";

            Executar<Usuario>(script, usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            string script = $@"UPDATE SISTEMA_FINANCEIRO.USUARIO SET
                               NM_USUARIO = @Nome,
                               DS_EMAIL_USUARIO = @Email,
                               NM_SENHA_USUARIO = @Senha,
                               CD_CPF_USUARIO = @Cpf,
                               NM_CARGO_USUARIO = @Cargo
                               WHERE CD_USUARIO = @Id";

            Executar<Usuario>(script, usuario);
        }

        public Usuario? ObterPorId(decimal id)
        {
            string script = $@"SELECT
                                    U.CD_USUARIO Id,
                                    U.NM_USUARIO Nome,
                                    U.DS_EMAIL_USUARIO Email,
                                    U.NM_SENHA_USUARIO Senha,
                                    U.CD_CPF_USUARIO Cpf,
                                    U.NM_CARGO_USUARIO Cargo
                               FROM SISTEMA_FINANCEIRO.USUARIO U
                               WHERE U.CD_USUARIO = @Id";

            return Obter<Usuario>(script, new { Id = id });
        }

        public Usuario? ObterPorCpfSenha(string cpf, string senha)
        {
            string script = $@"SELECT
                                    U.CD_USUARIO Id,
                                    U.NM_USUARIO Nome,
                                    U.DS_EMAIL_USUARIO Email,
                                    U.NM_SENHA_USUARIO Senha,
                                    U.CD_CPF_USUARIO Cpf,
                                    U.NM_CARGO_USUARIO Cargo
                               FROM SISTEMA_FINANCEIRO.USUARIO U
                               WHERE U.CD_CPF_USUARIO = @Cpf AND U.NM_SENHA_USUARIO = @Senha";

            return Obter<Usuario>(script, new { Cpf = cpf, Senha = senha });
        }

        public List<Usuario>? ObterListaPorUsuarioMaster(decimal idUsuario)
        {
            string script = $@"SELECT
                                    U.CD_USUARIO Id,
                                    U.NM_USUARIO Nome,
                                    U.DS_EMAIL_USUARIO Email,
                                    U.NM_SENHA_USUARIO Senha,
                                    U.CD_CPF_USUARIO Cpf,
                                    U.NM_CARGO_USUARIO Cargo
                               FROM SISTEMA_FINANCEIRO.AMR_USUARIO A
                                    INNER JOIN SISTEMA_FINANCEIRO.USUARIO U
                                        ON A.CD_USUARIO = U.CD_USUARIO
                               WHERE A.CD_USUARIO_MASTER = @idUsuario";

            return ObterLista<Usuario>(script, new { idUsuario });
        }

        public void AdicionarAmrUsuario(decimal idUsuario, decimal idUsuarioMaster)
        {
            string script = $@"INSERT INTO SISTEMA_FINANCEIRO.AMR_USUARIO 
                                    (CD_USUARIO,CD_USUARIO_MASTER) 
                               VALUES (@IdUsuario, @IdUsuarioMaster)";

            Executar<Usuario>(script, new {IdUsuario = idUsuario, IdUsuarioMaster = idUsuarioMaster});
        }
    }
}
