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
            try
            {
                var pilotos = _pilotoRepositorio.ObterTodos();
                if (!pilotos.Any())
                    return NotFound();

                return Ok(pilotos);
            }
            catch(Exception ex)
            {
                //_logger.Info(ex.ToString()); //Logando as falhas.
                //return BadRequest(ex.ToString()); //Opção perigosa devido ao risco de expor dados de banco de dados e etc.
                //return BadRequest("Ocorreu uma falha inesperada. Contacte o suporte técnico.");
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpGet("{id}", Name="Obter")]
        public IActionResult Obter(int id)
        {
            try
            {
                var piloto = _pilotoRepositorio.Obter(id);
                if (piloto == null)
                    return NotFound();

                return Ok(piloto);
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString()); //Logando as falhas.
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPost]
        public IActionResult AdicionarPiloto([FromBody] Piloto piloto)
        {
            try
            {
                if (_pilotoRepositorio.Existe(piloto.Id))
                    return StatusCode(409, "Já existe um piloto cadastrado com esta identificação");

                _pilotoRepositorio.Adicionar(piloto);

                return CreatedAtRoute("Obter", new { id = piloto.Id }, piloto);
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString()); //Logando as falhas.
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }                        
        }

        [HttpPut]
        public IActionResult AtualizarPiloto([FromBody] Piloto piloto)
        {
            try
            {
                if (!_pilotoRepositorio.Existe(piloto.Id))
                    return NotFound();

                _pilotoRepositorio.Atualizar(piloto);

                //Apenas indica que a operação ocorreu corretamente.
                return NoContent(); 
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString()); //Logando as falhas.
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPatch]
        public IActionResult AtualizarParcialmentePiloto(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString()); //Logando as falhas.
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverPiloto(int id)
        {
            try
            {
                var piloto = _pilotoRepositorio.Obter(id);
                if (piloto == null)
                    return NotFound();

                _pilotoRepositorio.Remover(piloto);

                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString()); //Logando as falhas.
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }
    }
}
