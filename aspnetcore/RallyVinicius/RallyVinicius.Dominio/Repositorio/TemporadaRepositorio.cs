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
    public class TemporadaRepositorio : ITemporadaRepositorio
    {
        private readonly RallyDbContexto _rallyDbContexto;

        public TemporadaRepositorio(RallyDbContexto rallyDbContexto)
        {
            _rallyDbContexto = rallyDbContexto;
        }

        public void Adicionar(Temporada temporada)
        {
            _rallyDbContexto.Temporadas.Add(temporada);
            _rallyDbContexto.SaveChanges();
        }

        public void Atualizar(Temporada temporada)
        {            
            if (_rallyDbContexto.Entry(temporada).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {                
                _rallyDbContexto.Attach(temporada);                
                _rallyDbContexto.Entry(temporada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {                
                _rallyDbContexto.Update(temporada);
            }
                        
            _rallyDbContexto.SaveChanges();
        }

        public bool Existe(int temporadaId)
        {
            return _rallyDbContexto.Temporadas.Any(x => x.Id == temporadaId);
        }

        public Temporada Obter(int temporadaId)
        {
            return _rallyDbContexto.Temporadas.FirstOrDefault(x => x.Id == temporadaId);
        }

        public ICollection<Temporada> ObterTodos()
        {
            return _rallyDbContexto.Temporadas.ToList();
        }

        public void Remover(Temporada temporada)
        {
            _rallyDbContexto.Temporadas.Remove(temporada);
            _rallyDbContexto.SaveChanges();
        }
    }
}
