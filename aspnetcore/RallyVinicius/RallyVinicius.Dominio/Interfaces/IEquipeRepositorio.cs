using RallyVinicius.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RallyVinicius.Dominio.Interfaces
{
    public interface IEquipeRepositorio
    {
        void Adicionar(Equipe equipe);
        ICollection<Equipe> ObterTodos();
        bool Existe(int equipeId);
        Equipe Obter(int equipeId);
        void Atualizar(Equipe equipe);
        void Remover(Equipe equipe);
    }
}
