using RallyVinicius.Dominio.DbContexto;
using RallyVinicius.Dominio.Entidades;
using RallyVinicius.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RallyVinicius.Dominio.Repositorio
{
    public class EquipeRepositorio : IEquipeRepositorio
    {
        private readonly RallyDbContexto _rallyDbContexto;

        public EquipeRepositorio(RallyDbContexto rallyDbContexto)
        {
            _rallyDbContexto = rallyDbContexto;
        }

        public void Adicionar(Equipe equipe)
        {
            _rallyDbContexto.Equipes.Add(equipe);
        }

        public void Atualizar(Equipe equipe)
        {
            if (_rallyDbContexto.Entry(equipe).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _rallyDbContexto.Attach(equipe);
                _rallyDbContexto.Entry(equipe).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _rallyDbContexto.Update(equipe);
            }

            _rallyDbContexto.SaveChanges();
        }

        public bool Existe(int equipeId)
        {
            return _rallyDbContexto.Equipes.Any(x => x.Id == equipeId);
        }

        public Equipe Obter(int equipeId)
        {
            return _rallyDbContexto.Equipes.FirstOrDefault(x => x.Id == equipeId);
        }

        public ICollection<Equipe> ObterTodos()
        {
            return _rallyDbContexto.Equipes.ToList();
        }

        public void Remover(Equipe equipe)
        {
            _rallyDbContexto.Equipes.Remove(equipe);
            _rallyDbContexto.SaveChanges();
        }
    }
}
