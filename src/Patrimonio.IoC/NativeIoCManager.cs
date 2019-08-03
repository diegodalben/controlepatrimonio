using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patrimonio.Business.Repositories;
using Patrimonio.Business.Services;
using Patrimonio.Business.Services.Abstractions;
using Patrimonio.Business.Validations.Factories;
using Patrimonio.Business.BusinessRules.Factories;
using Patrimonio.DataAccess.AdoNet;

namespace Patrimonio.IoC
{
    public static class NativeIoCManager
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            #region DataAccess

            services.AddScoped<IMarcaRepository>(factory => 
            {
                return new MarcaAdoDataAccess
                (
                    new SqlConnection(configuration.GetValue<string>("ConnectionString"))
                );
            });

            services.AddScoped<IPatrimonioRepository>(factory => 
            {
                return new PatrimonioAdoDataAccess
                (
                    new SqlConnection(configuration.GetValue<string>("ConnectionString"))
                );
            });

            #endregion

            #region Services

            services.AddScoped<IMarcaService>(factory =>
            {
                return new MarcaService
                (
                    factory.GetService<IMarcaRepository>(),
                    new InsertMarcaValidationFactory(factory.GetService<IMarcaRepository>()),
                    new UpdateMarcaValidationFactory(factory.GetService<IMarcaRepository>())
                );
            });

            services.AddScoped<IPatrimonioService>(factory => 
            {
                return new PatrimonioService
                (
                    factory.GetService<IPatrimonioRepository>(),
                    new InsertPatrimonioValidationFactory(),
                    new UpdatePatrimonioValidationFactory(),
                    new InsertPatrimonioRuleFactory()
                );
            });

            #endregion
        }
    }
}
