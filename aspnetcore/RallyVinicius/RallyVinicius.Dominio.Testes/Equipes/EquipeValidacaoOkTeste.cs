using Microsoft.VisualStudio.TestTools.UnitTesting;
using RallyVinicius.Dominio.Entidades;
using System.Linq;

namespace RallyVinicius.Dominio.Testes.Temporadas
{
    [TestClass]
    public class EquipeValidacaoOkTeste
    {
        Equipe equipe1;
        

        [TestMethod]
        public void EquipeValidadoCorretamente()
        {
            equipe1 = new Equipe()
            {                
                CodigoIdentificador = "KTM",
                Nome = "EquipeTest"
            };
            
            Assert.IsTrue(equipe1.Validado());
        }      

    }
}
