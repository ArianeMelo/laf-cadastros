using LAF.Cadastros.Application;
using LAF.Cadastros.Domain.Interfaces.Application;
using LAF.Cadastros.Domain.Interfaces.Repository;
using LAF.Cadastros.Repository;
using LAF.Cadastros.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LAF.Cadastros.IoC.Dependency
{
    public static class InjecaoDependencia
    {   
        public static void Registra(IServiceCollection services)
        {
            Container.RegistrarMapeamentosDapper();

            //Repository
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            //Application
            services.AddScoped<IFornecedorApplication, FornecedorApplication>();
        }     
    }
}
