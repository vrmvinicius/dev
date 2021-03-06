using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RallyVinicius.Dominio.DbContexto;
using RallyVinicius.Dominio.Interfaces;
using RallyVinicius.Dominio.Repositorio;

namespace RallyVinicius.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Mecanismo de inje��o de depend�ncia incluindo o nosso DbContext como um servi�o, e especificando o banco de dados.
            services.AddDbContext<RallyDbContexto>(opt => opt.UseInMemoryDatabase("RallyDB"), 
                ServiceLifetime.Scoped, 
                ServiceLifetime.Scoped);
            
            //Padr�o do EFCore.
            services.AddControllers()
                    .AddNewtonsoftJson();

            //Registra a infje��o de depend�ncia entre Interfaces e Classes dos repositorios.
            services.AddScoped<IPilotoRepositorio, PilotoRepositorio>();
            services.AddScoped<ITemporadaRepositorio, TemporadaRepositorio>();
            services.AddScoped<ITelemetriaRepositorio, TelemetriaRepositorio>();
            services.AddScoped<IEquipeRepositorio, EquipeRepositorio>();

            //Permite a utiliza��o do 'AutoMapper'.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
