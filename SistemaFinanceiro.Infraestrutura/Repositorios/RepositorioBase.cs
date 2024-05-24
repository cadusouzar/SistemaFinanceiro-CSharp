using SistemaFinanceiro.Infraestrutura.Servicos;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Infraestrutura.Repositorios
{
    public class RepositorioBase 
    {
        IConfiguration _configuracao;

        public RepositorioBase(IConfiguration configuration)
        {
            _configuracao = configuration;
        }

        public void Executar<T>(string query, object? parametros)
        {
            using var db = ServicoConexao.ObterConexao(_configuracao);
            var result = db.Execute(query, parametros);
        }

        public T? Obter<T>(string consulta, object? parametros = null)
        {
            using var db = ServicoConexao.ObterConexao(_configuracao);
            var retorno = db.Query<T>(consulta, parametros).FirstOrDefault();
            return retorno;
        }

        public List<T> ObterLista<T>(string consulta, object? parametros = null)
        {
            using var db = ServicoConexao.ObterConexao(_configuracao);
            var retorno = db.Query<T>(consulta, parametros).ToList();
            return retorno;
        }
    }
}
