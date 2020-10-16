using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEconomica.Vinicius.Dominio.Entidades
{
    public class Endereco : Entidade
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

        /// <summary>
        /// 1 - Residencial, 2 - Trabalho.
        /// </summary>
        public int TipoEnderecoId { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Rua))
                NotificacaoDominio.AddErro("Rua deve informado");

            if (Numero == 0)
                NotificacaoDominio.AddErro("Numero deve informado");

            if (TipoEnderecoId == 0)
                NotificacaoDominio.AddErro("Tipo de Endereco deve ser informado");
        }
    }
}
