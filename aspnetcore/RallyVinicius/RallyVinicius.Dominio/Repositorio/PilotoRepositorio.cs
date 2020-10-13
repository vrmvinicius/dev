using RallyVinicius.Dominio.DbContexto;
using RallyVinicius.Dominio.Entidades;
using RallyVinicius.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RallyVinicius.Dominio.Repositorio
{
    public class PilotoRepositorio : IPilotoRepositorio
    {
        private readonly RallyDbContexto _rallyDbContexto;

        public PilotoRepositorio(RallyDbContexto rallyDbContexto)
        {
            _rallyDbContexto = rallyDbContexto;
        }

        public void Adicionar(Piloto piloto)
        {
            _rallyDbContexto.Pilotos.Add(piloto);
            _rallyDbContexto.SaveChanges();
        }

        public ICollection<Piloto> ObterTodos()
        {
            return _rallyDbContexto.Pilotos.ToList();
        }

        public ICollection<Piloto> ObterTodosPilotos(string nome)
        {
            return _rallyDbContexto.Pilotos.Where(x => x.Nome.Contains(nome))
                                           .ToList();
        }
    }
}
