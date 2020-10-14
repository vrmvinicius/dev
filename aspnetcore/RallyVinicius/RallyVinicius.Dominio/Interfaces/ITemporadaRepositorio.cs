using RallyVinicius.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RallyVinicius.Dominio.Interfaces
{
    public interface ITemporadaRepositorio
    {
        void Adicionar(Temporada temporada);
        ICollection<Temporada> ObterTodos();
        bool Existe(int temporadaId);
        Temporada Obter(int temporadaId);
        void Atualizar(Temporada temporada);
        void Remover(Temporada temporada);
    }
}
