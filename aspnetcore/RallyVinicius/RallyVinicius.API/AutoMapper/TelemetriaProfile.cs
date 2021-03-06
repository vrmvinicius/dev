﻿using AutoMapper;
using RallyVinicius.API.Modelo;
using RallyVinicius.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyVinicius.API.AutoMapper
{
    public class TelemetriaProfile : Profile
    {
        public TelemetriaProfile()
        {
            CreateMap<Telemetria, TelemetriaModelo>();
            CreateMap<TelemetriaModelo, Telemetria>();
        }
    }
}
