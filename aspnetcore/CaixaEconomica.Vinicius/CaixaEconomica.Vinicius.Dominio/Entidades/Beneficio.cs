using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixaEconomica.Vinicius.Dominio.Entidades
{
    public class Beneficio : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public bool Ativo { get; set; }

        // Relacionamento de 1(Beneficio) para Muitos(BeneficioPessoa). Utilizando 'backing field com hashset'.
        private readonly HashSet<BeneficioPessoa> _beneficioPessoas = new HashSet<BeneficioPessoa>();
        public IEnumerable<BeneficioPessoa> BeneficioPessoas => _beneficioPessoas.ToList().AsReadOnly();
    }
}
