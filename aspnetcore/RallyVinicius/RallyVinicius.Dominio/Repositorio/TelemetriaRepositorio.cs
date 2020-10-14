using Microsoft.EntityFrameworkCore.Internal;
using RallyVinicius.Dominio.DbContexto;
using RallyVinicius.Dominio.Entidades;
using RallyVinicius.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RallyVinicius.Dominio.Repositorio
{
    public class TelemetriaRepositorio : ITelemetriaRepositorio
    {
        private readonly RallyDbContexto _rallyDbContexto;

        public TelemetriaRepositorio(RallyDbContexto rallyDbContexto)
        {
            _rallyDbContexto = rallyDbContexto;
        }

        public void Adicionar(Telemetria telemetria)
        {
            _rallyDbContexto.Telemetria.Add(telemetria);
        }

        public void Atualizar(Telemetria telemetria)
        {
            if(_rallyDbContexto.Entry(telemetria).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _rallyDbContexto.Attach(telemetria);
                _rallyDbContexto.Entry(telemetria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _rallyDbContexto.Update(telemetria);
            }

            _rallyDbContexto.SaveChanges();
        }

        public bool Existe(int telemetriaId)
        {
            return _rallyDbContexto.Telemetria.Any(x => x.Id == telemetriaId);
        }

        public Telemetria Obter(int telemetriaId)
        {
            return _rallyDbContexto.Telemetria.FirstOrDefault(x => x.Id == telemetriaId);
        }

        public ICollection<Telemetria> ObterTodos()
        {
            return _rallyDbContexto.Telemetria.ToList();
        }

        public ICollection<Telemetria> ObterTodosPorEquipe(int equipeId)
        {
            return _rallyDbContexto.Telemetria.Where(x => x.EquipeId == equipeId).ToList();
        }

        public void Remover(Telemetria telemetria)
        {
            _rallyDbContexto.Telemetria.Remove(telemetria);
            _rallyDbContexto.SaveChanges();
        }
    }
}
