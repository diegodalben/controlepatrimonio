using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Patrimonio.API.Filters;
using Patrimonio.IoC;

namespace Patrimonio.API
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builderConfig = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json");

            Configuration = builderConfig.Build();

            services.AddMvc
                    (
                        config => 
                        {
                            config.Filters.Add(typeof(CustomExceptionFilter));
                        }
                    )
                    .AddJsonOptions
                    (
                        options =>
                        {
                            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                        }
                    );

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>{
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            // Configure the IoC.
            NativeIoCManager.Register(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure
        (
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory
        )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");
            app.UseMvc();

            loggerFactory.AddFile("Log/Api_Log.txt");
        }
    }
}