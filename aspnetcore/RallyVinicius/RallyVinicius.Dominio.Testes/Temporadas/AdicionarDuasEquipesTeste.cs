using Microsoft.VisualStudio.TestTools.UnitTesting;
using RallyVinicius.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RallyVinicius.Dominio.Testes.Temporadas
{
    [TestClass]
    public class AdicionarDuasEquipesTeste
    {
        Temporada temporada;
        Equipe equipe1;
        Equipe equipe2;
        Equipe equipe3;

        [TestInitialize]
        public void Initialize() //Preparação do ambiente do teste.
        {
            temporada = new Temporada();
            temporada.Id = 1;
            temporada.Nome = "Temporada 2020";

            equipe1 = new Equipe();
            equipe1.Id = 1;
            equipe1.Nome = "Equipe1";

            equipe2 = new Equipe();
            equipe2.Id = 2;
            equipe2.Nome = "Equipe2";

            equipe3 = null;

            temporada.AdicionarEquipe(equipe1);
            temporada.AdicionarEquipe(equipe2);
            temporada.AdicionarEquipe(equipe3);
        }

        [TestMethod]
        public void DuasEquipesAdicionadasCorretamente() //Nomenclatura clara e objetiva.
        {
            Assert.IsTrue(temporada.Equipes.Count() == 2);
        }
    }
}
