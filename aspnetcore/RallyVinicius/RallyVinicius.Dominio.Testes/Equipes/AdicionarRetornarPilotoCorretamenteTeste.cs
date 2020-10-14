﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RallyVinicius.Dominio.Entidades;
using System.Linq;

namespace RallyVinicius.Dominio.Testes.Temporadas
{
    [TestClass]
    public class AdicionarRetornarPilotoCorretamenteTeste
    {
        Equipe equipe;
        Equipe piloto1;
        Equipe piloto2;
        Equipe piloto3;
        Equipe piloto1Retorno;
        Equipe piloto2Retorno;
        Equipe piloto3Retorno;

        [TestInitialize]
        public void Initialize()
        {
            equipe = new Equipe();
            equipe.Id = 1;
            equipe.Nome = "EquipeTeste";
            equipe.CodigoIdentificador = "JKL";
                        
            piloto1 = new Equipe();
            piloto1.Id = 1;
            piloto1.Nome = "Joao";

            piloto2 = new Equipe();
            piloto2.Id = 2;
            piloto2.Nome = "Maria";

            piloto3 = new Equipe();
            piloto3.Id = 3;
            piloto3.Nome = "";

            equipe.AdicionarPiloto(piloto1);
            equipe.AdicionarPiloto(piloto2);
            equipe.AdicionarPiloto(piloto3);

            piloto1Retorno = equipe.ObterPorId(piloto1.Id);
            piloto2Retorno = equipe.ObterPorId(piloto2.Id);
            piloto3Retorno = equipe.ObterPorId(piloto3.Id);
        }

        [TestMethod]
        public void IdPiloto1RetornadoCorretamente()
        {
            Assert.IsTrue(piloto1.Id == piloto1Retorno.Id);
        }

        [TestMethod]
        public void NomePiloto1RetornadoCorretamente()
        {
            Assert.IsTrue(piloto1.Nome == piloto1Retorno.Nome);
        }

        [TestMethod]
        public void IdPiloto2RetornadoCorretamente()
        {
            Assert.IsTrue(piloto2.Id == piloto2Retorno.Id);
        }

        [TestMethod]
        public void NomePiloto2RetornadoCorretamente()
        {
            Assert.IsTrue(piloto2.Nome == piloto2Retorno.Nome);
        }


        [TestMethod]
        public void Piloto3NaoRetornadoPorqueNaoEhValido()
        {
            Assert.IsNull(piloto3Retorno);
        }


    }
}
