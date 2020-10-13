using Microsoft.AspNetCore.Mvc;
using RallyVinicius.Dominio.Entidades;
using RallyVinicius.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyVinicius.API.Controllers
{
    [ApiController]
    [Route("api/pilotos")] //Pluralização do nome.
    public class PilotoController : ControllerBase
    {
        private IPilotoRepositorio _pilotoRepositorio;
        public PilotoController(IPilotoRepositorio pilotoRepositorio)
        {
            _pilotoRepositorio = pilotoRepositorio;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            List<Piloto> pilotos = new List<Piloto>();
            Piloto piloto = new Piloto();
            piloto.Id = 1;
            piloto.Nome = "Piloto Teste";
            pilotos.Add(piloto);
            return Ok(pilotos);
            //return Ok(_pilotoRepositorio.ObterTodos());
        }

        [HttpPost]
        public IActionResult AdicionarPiloto([FromBody] Piloto piloto)
        {
            _pilotoRepositorio.Adicionar(piloto);
            return Ok();
        }
    }
}
