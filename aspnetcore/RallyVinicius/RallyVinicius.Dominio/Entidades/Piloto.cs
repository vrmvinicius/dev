using System;
using System.Collections.Generic;
using System.Text;

namespace RallyVinicius.Dominio.Entidades
{
    public class Piloto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public int EquipeId { get; set; }
        public virtual Equipe Equipe { get; set; }

        public bool Validado()
        {
            if (string.IsNullOrEmpty(Nome))
                return false;

            return true;
        }
    }
}
