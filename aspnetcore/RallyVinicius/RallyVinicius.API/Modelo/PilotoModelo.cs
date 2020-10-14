using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RallyVinicius.API.Modelo
{
    public class PilotoModelo
    {
        [Key]             
        public int Id { get; set; }

        [Required(ErrorMessage="Campo nome é obrigatório.")]
        [MinLength(2, ErrorMessage="Campo nome deve ter no mínimo 2 caracteres.")]
        [MaxLength(50, ErrorMessage="Campo nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage="Campo sobrenome é obrigatório.")]
        [MinLength(2, ErrorMessage = "Campo sobrenome deve ter no mínimo 2 caracteres.")]
        [MaxLength(50, ErrorMessage = "Campo sobrenome deve ter no máximo 50 caracteres.")]
        public string Sobrenome { get; set; }

        public int EquipeId { get; set; }
        public string NomeCompleto
        {
            get => $"{Nome} {Sobrenome}";
        }
    }
}
