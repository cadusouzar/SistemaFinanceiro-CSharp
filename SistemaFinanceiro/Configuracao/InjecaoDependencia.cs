using SistemaFinanceiro.Dominio.Interfaces;
using SistemaFinanceiro.Dominio.Servicos;
using SistemaFinanceiro.Infraestrutura.Repositorios;

namespace SistemaFinanceiro.Configuracao
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependencia(this IServiceCollection services)
        {
            services.AddTransient<IServicoUsuario, ServicoUsuario>();
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();

            services.AddTransient<IServicoTransacao, ServicoTransacao>();
            services.AddTransient<IRepositorioTransacao, RepositorioTransacao>();


            services.AddTransient<IServicoConta, ServicoConta>();
            services.AddTransient<IRepositorioConta, RepositorioConta>();

            services.AddTransient<IRepositorioFatura, RepositorioFatura>();
        }
    }
}
