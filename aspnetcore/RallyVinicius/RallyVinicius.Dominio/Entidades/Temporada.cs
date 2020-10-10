using System;
using System.Collections.Generic;
using System.Linq;

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
            if (equipe != null && equipe.Validado())
            {                
                if(!Equipes.Any(e => e.Id == equipe.Id))
                    Equipes.Add(equipe);                
            }
        }

        public Equipe ObterPorId(int id)
        {
            return Equipes.FirstOrDefault(e => e.Id == id);
        }
    }
}
