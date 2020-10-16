using CaixaEconomica.Vinicius.Dominio.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixaEconomica.Vinicius.Dominio.Entidades
{
    public class Pessoa : Entidade
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public int Idade { get; set; }
        public int QuantidadeFilhos { get; set; }
                
        /// <summary>
        /// 2 - Empregado, 11 - Profissional Liberal
        /// </summary>
        public int CodigoOcupacao { get; set; }
                
        // Backing Field com Hashset.        
        private readonly HashSet<Endereco> _enderecos = new HashSet<Endereco>();
        public IEnumerable<Endereco> Enderecos => _enderecos.ToList().AsReadOnly();

        public Pessoa()
        {
            //Vai ficar dessa forma enquanto a injeção de dep.. não estiver configurado
            SetNotificacao(new NotificacaoDominio());
        }

        /// <summary>
        /// Backing Field com Hashset.
        /// </summary>        
        public void AdicionarEndereco(Endereco endereco)
        {
            if (endereco == null)
            {
                NotificacaoDominio.AddErro("Erro: endereco deve ser instanciado");
            }
            else
            {
                // vai ficar dessa forma enquanto a injeção de dep.. não estiver configurado
                endereco.SetNotificacao(NotificacaoDominio);

                endereco.Validar();
                if (endereco.EhValido())
                    _enderecos.Add(endereco);
                else
                    NotificacaoDominio.AddErro("Endereco não foi adicionado porque não é válido");
            }
        }


        // Relacionamento de 1(Pessoa) para Muitos(BeneficioPessoa). Utilizando 'backing field com hashset'.
        private readonly HashSet<BeneficioPessoa> _beneficioPessoas = new HashSet<BeneficioPessoa>();
        public IEnumerable<BeneficioPessoa> BeneficioPessoas => _beneficioPessoas.ToList().AsReadOnly();
    }
}
