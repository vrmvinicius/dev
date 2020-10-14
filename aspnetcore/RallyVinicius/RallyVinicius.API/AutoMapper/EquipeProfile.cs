using AutoMapper;
using RallyVinicius.API.Modelo;
using RallyVinicius.Dominio.Entidades;
using RallyVinicius.Dominio.Interfaces;
using RallyVinicius.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyVinicius.API.AutoMapper
{
    public class EquipeProfile : Profile
    {
        public EquipeProfile()
        {
            CreateMap<Equipe, EquipeModelo>();
            CreateMap<EquipeModelo, Equipe>();
        }
    }
}
