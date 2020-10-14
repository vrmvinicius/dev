using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RallyVinicius.Dominio.Entidades
{
    public class Equipe
    {
        public int Id { get; set; }
        public string CodigoIdentificador { get; set; }
        public string Nome { get; set; }

        public int TemporadaId { get; set; } //Facilitar o EntityFramework no mapeamento.
        public virtual Temporada Temporada { get; set; } //O virtual indica carregamento sob demanda do EntityFramework.

        public ICollection<Equipe> Pilotos { get; set; }

        public Equipe()
        {
            Pilotos = new List<Equipe>();
        }

        public void AdicionarPiloto(Equipe equipe)
        {
            if (equipe != null && equipe.Validado())
            {
                if (!Pilotos.Any(p => p.Id == equipe.Id))
                    Pilotos.Add(equipe);
            }
        }

        public Equipe ObterPorId(int id)
        {
            return Pilotos.FirstOrDefault(p => p.Id == id);
        }

        public bool Validado()
        {
            if (string.IsNullOrEmpty(Nome))
                return false;

            if (string.IsNullOrEmpty(CodigoIdentificador))
                return false;

            return true;
        }
    }
}
