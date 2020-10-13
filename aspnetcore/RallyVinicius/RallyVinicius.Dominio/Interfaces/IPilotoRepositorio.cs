using RallyVinicius.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RallyVinicius.Dominio.Interfaces
{
    public interface IPilotoRepositorio
    {
        void Adicionar(Piloto piloto);
        ICollection<Piloto> ObterTodos();
        bool Existe(int pilotoId);
        Piloto Obter(int pilotoId);
        void Atualizar(Piloto piloto);
        void Remover(Piloto piloto);
    }
}
