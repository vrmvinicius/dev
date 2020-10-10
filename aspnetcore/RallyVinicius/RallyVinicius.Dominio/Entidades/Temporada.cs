using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RallyVinicius.Dominio.Entidades
{
    public class Temporada
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; } //Pode cadastrar a temporada sem data para fim, por isso, 'nullable'.

        public ICollection<Equipe> Equipes { get; set; }
    }
}
