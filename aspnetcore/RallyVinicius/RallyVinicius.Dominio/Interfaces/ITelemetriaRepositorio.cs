using RallyVinicius.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RallyVinicius.Dominio.Interfaces
{
    public interface ITelemetriaRepositorio
    {
        void Adicionar(Telemetria telemetria);
        ICollection<Telemetria> ObterTodos();
        ICollection<Telemetria> ObterTodosPorEquipe(int equipeÌd);
        bool Existe(int telemetriaId);
        Telemetria Obter(int telemetriaId);
        void Atualizar(Telemetria telemetria);
        void Remover(Telemetria telemetria);

    }
}
