using System;
using System.Collections.Generic;
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

        public ICollection<Piloto> Pilotos { get; set; }

        public bool Validado()
        {
            if (String.IsNullOrEmpty(Nome))
                return false;

            return true;
        }
    }
}
