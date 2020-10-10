using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Exemplo1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Indica a utiliza��o de controllers pelo servidor de aplica��o adicionando os mesmos automaticamente.
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            //Indica o uso do roteamento para acesso aos endpoints. Obrigat�ria esta chamada e que esta abaixo.s
            app.UseRouting();

            //Configura��o dos endpoints.
            app.UseEndpoints(endpoints =>
            {
                //Definindo que ser�o utilziados controllers.
                endpoints.MapControllers();
            });
        }
    }
}
