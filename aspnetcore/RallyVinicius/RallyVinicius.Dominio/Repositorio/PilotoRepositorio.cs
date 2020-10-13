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

        public void Atualizar(Piloto piloto)
        {
            //Define que o Entity Framework buscará o objeto relacionado em seu cache a este passado por parâmetro.
            _rallyDbContexto.Attach(piloto); 
            //Define o status como totalmente alterado.
            _rallyDbContexto.Entry(piloto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //Efetiva as alterações no banco.
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

        public bool Existe(int pilotoId)
        {
            return _rallyDbContexto.Pilotos.Any(x => x.Id == pilotoId);
        }

        public Piloto Obter(int pilotoId)
        {
            return _rallyDbContexto.Pilotos.FirstOrDefault(x => x.Id == pilotoId);
        }

        public void Remover(Piloto piloto)
        {
            _rallyDbContexto.Pilotos.Remove(piloto);
            _rallyDbContexto.SaveChanges();
        }
    }
}
