using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro.Infraestrutura.Servicos
{
    public class ServicoConexao
    {
        public static MySqlConnection ObterConexao(IConfiguration configuracao)
        {
            var connectionString = configuracao["ConnectionStrings:MysqlConnection"];
            MySqlConnection conexao = new MySqlConnection(connectionString);
            return conexao;
        }
    }
}
