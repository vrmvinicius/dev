using CaixaEconomica.Vinicius.Dominio.Entidades;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Discovery;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CaixaEconomica.Vinicius.Testes.Dominio.Entidades.Pessoa
{
    [TestClass]
    public class PessoaTemPeloMenosUmEnderecoValido
    {
        private CaixaEconomica.Vinicius.Dominio.Entidades.Pessoa pessoa;
        private Endereco endereco;

        [TestInitialize]
        public void Init()
        {
            pessoa = new Vinicius.Dominio.Entidades.Pessoa();
            endereco = new Endereco() { Id = 1, Rua = "asdasdasd", Numero = 10, TipoEnderecoId = 1 };
            pessoa.AdicionarEndereco(endereco);
        }

        [TestMethod]
        public void PessoaTemEnderecoValido()
        {
            Assert.IsTrue(pessoa.Enderecos.Any());
        }
    }
}
