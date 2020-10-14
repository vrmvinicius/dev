using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RallyVinicius.API.Modelo
{
    public class TemporadaModelo
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nome da temporada é obrigatório.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Data de início da temoprada é obrigatório")]
        public DateTime DataInicio { get; set; }
        
        public DateTime? DataFim { get; set; }
    }
}
