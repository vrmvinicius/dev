using System;
using System.Collections.Generic;

namespace RallyVinicius.Dominio.Entidades
{
    public class Temporada
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; } //Pode cadastrar a temporada sem data para fim, por isso, 'nullable'.

        public ICollection<Equipe> Equipes { get; set; }

        public Temporada()
        {
            Equipes = new List<Equipe>();
        }

        public void AdicionarEquipe(Equipe equipe)
        {
            if (equipe != null)
            {
                if (equipe.Validado())
                {
                    Equipes.Add(equipe);
                }
            }
        }
    }
}
