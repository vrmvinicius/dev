using System;
using System.Collections.Generic;
using System.Text;

namespace RallyVinicius.Dominio.Entidades
{
    public class Telemetria
    {
        public int Id { get; set; }

        public int TemporadaId { get; set; } //Relacionamento com Temporada.
        public int PilotoId { get; set; } //Relacionamento com Piloto.

        public DateTime Data { get; set; }
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
