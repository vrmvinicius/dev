using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RallyVinicius.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RallyVinicius.Dominio.DbContexto
{
    public class BaseDados
    {
        public static void CargaInicial(IServiceProvider serviceProvider)
        {
            using(var context = new RallyDbContexto(serviceProvider.GetRequiredService<DbContextOptions<RallyDbContexto>>()))
            {
                var temporada = new Temporada
                {
                    Id = 1,
                    Nome = "Temporada 2020",
                    DataInicio = DateTime.Now
                };

                var equipe1 = new Equipe
                {
                    Id = 1,
                    Nome = "Equipe Azul",
                    CodigoIdentificador = "Azl"
                };
                var equipe2 = new Equipe
                {
                    Id = 2,
                    Nome = "Equipe Vermelha",
                    CodigoIdentificador = "Vrl"
                };

                var pilotoPedro = new Equipe
                {
                    Id = 1,
                    Nome = "Pedro"
                };
                var pilotoCarlos = new Equipe
                {
                    Id = 2,
                    Nome = "Carlos"
                };
                var pilotoAndre = new Equipe
                {
                    Id = 3,
                    Nome = "André"
                };

                equipe1.AdicionarPiloto(pilotoPedro);
                equipe1.AdicionarPiloto(pilotoCarlos);
                equipe2.AdicionarPiloto(pilotoAndre);

                temporada.AdicionarEquipe(equipe1);
                temporada.AdicionarEquipe(equipe2);

                var telemetria1 = new Telemetria();
                telemetria1.Id = 1;
                telemetria1.EquipeId = 1;
                telemetria1.Data = DateTime.Now;
                telemetria1.Hora = DateTime.Now.TimeOfDay;

                var telemetria2 = new Telemetria();
                telemetria2.Id = 2;
                telemetria2.EquipeId = 1;
                telemetria2.Data = DateTime.Now;
                telemetria2.Hora = DateTime.Now.TimeOfDay;

                var telemetria3 = new Telemetria();
                telemetria3.Id = 3;
                telemetria3.EquipeId = 2;
                telemetria3.Data = DateTime.Now;
                telemetria3.Hora = DateTime.Now.TimeOfDay;

                context.Add(temporada);
                context.Add(telemetria1);
                context.Add(telemetria2);
                context.Add(telemetria3);

                context.SaveChanges();
            }
        }
    }
}
