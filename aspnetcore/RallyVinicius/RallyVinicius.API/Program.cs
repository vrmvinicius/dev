using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using RallyVinicius.Dominio.DbContexto;

namespace RallyVinicius.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config")
                                    .GetCurrentClassLogger();

            logger.Info("Iniciando a WEB-API..");

            try
            {
                //CreateHostBuilder(args).Build().Run();
                
                //Obt�m a inst�ncia da aplica��o que ser� executada no servidor. 'Startup.ConfigureServices' ser� chamado.
                var host = CreateHostBuilder(args).Build();

                //Antes de executar a aplica��o no server, inclui os dados para teste.
                using(var scope = host.Services.CreateScope())
                {
                    BaseDados.CargaInicial(scope.ServiceProvider);
                }

                //Executa a aplica��o no servidor. 'Startup.Configure' ser� chamado.
                host.Run();
            }
            catch(Exception ex)
            {
                logger.Error(ex, "Aplica��o parou de funcionar.");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                              .UseNLog();
                });
    }
}
