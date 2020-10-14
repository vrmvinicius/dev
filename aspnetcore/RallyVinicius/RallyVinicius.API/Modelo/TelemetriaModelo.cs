using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RallyVinicius.API.Modelo
{
    public class TelemetriaModelo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Equipe não identificada.")]
        public int EquipeId { get; set; }

        [Required(ErrorMessage = "Data da equipe não foi recebida.")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Hora da equipe não foi recebida.")]
        public TimeSpan Hora { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public decimal PercentualCombustivel { get; set; }
        public double Velocidade { get; set; }
        public double RPM { get; set; }

        public int TemperaturaExterna { get; set; }
        public int TemperaturaMotor { get; set; }

        public bool PedalAcelerador { get; set; } //No ato da transmissão da informação estava acelerando?
        public bool PedalFreio { get; set; } //No ato da transmissão da informação estava freiando?
    }
}
