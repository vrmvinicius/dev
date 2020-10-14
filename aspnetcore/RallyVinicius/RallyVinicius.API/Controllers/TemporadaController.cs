using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RallyVinicius.API.Modelo;
using RallyVinicius.Dominio.Entidades;
using RallyVinicius.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyVinicius.API.Controllers
{
    [ApiController]
    [Route("api/temporadas")] //Pluralização do nome.
    public class TemporadaController : ControllerBase
    {
        //Todos recebem suas instâncias via 'injeção de dependência'.
        private readonly ITemporadaRepositorio _temporadaRepositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<TemporadaController> _logger;

        public TemporadaController(ITemporadaRepositorio temporadaRepositorio, IMapper mapper, ILogger<TemporadaController> logger)
        {
            _temporadaRepositorio = temporadaRepositorio;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id}", Name = "ObterTemporada")]
        public IActionResult Obter(int id)
        {
            try
            {
                var temporada = _temporadaRepositorio.Obter(id);

                if (temporada == null)
                    return NotFound();

                var temporadaModelo = _mapper.Map<TemporadaModelo>(temporada);

                return Ok(temporadaModelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPost]
        public IActionResult AdicionarTemporada([FromBody] TemporadaModelo temporadaModelo)
        {
            try
            {
                _logger.LogInformation("Adicionando um piloto..");

                //Repassa do modelo para a entidade de domínio de forma automatica.
                var temporada = _mapper.Map<Temporada>(temporadaModelo);

                if (_temporadaRepositorio.Existe(temporada.Id))
                    return StatusCode(409, "Já existe um piloto cadastrado com esta identificação");

                _temporadaRepositorio.Adicionar(temporada);

                var temporadaModeloRetorno = _mapper.Map<TemporadaModelo>(temporada);

                //Retorna o caminho completo do novo 'recurso'.
                return CreatedAtRoute("ObterTemporada", new { id = temporada.Id }, temporadaModeloRetorno);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPut]
        public IActionResult AtualizarTemporada([FromBody] TemporadaModelo temporadaModelo)
        {
            try
            {
                var temporada = _mapper.Map<Temporada>(temporadaModelo);

                if (!_temporadaRepositorio.Existe(temporada.Id))
                    return NotFound();

                _temporadaRepositorio.Atualizar(temporada);

                //Apenas indica que a operação ocorreu corretamente.
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizarParcialmenteTemporada(int id, [FromBody] JsonPatchDocument<TemporadaModelo> patchTemporadaModelo)
        {
            //@patchPiloto - Conterá o fragmento de 'json' com os dados a serem atualizados.            
            //Exemplo de fragmento de json (patch):
            //[
            //    {
            //        "op":"replace",
            //        "path": "/nome",
            //        "value": "Piloto Teste 222"
            //    }
            //]
            try
            {
                //Se não existe já sai.
                if (!_temporadaRepositorio.Existe(id))
                    return NotFound();

                //Obtém o objeto monitorado do Entity Framework da base.
                var temporada = _temporadaRepositorio.Obter(id);
                //Gera uma instância do objeto de negócio para o objeto de modelo.
                var temporadaModelo = _mapper.Map<TemporadaModelo>(temporada);

                //Aplica as alterações do modelo.
                patchTemporadaModelo.ApplyTo(temporadaModelo);
                //Mapeia no objeto retornado anteriormente pelo entity framework (aqui não pode gerar nova instância se não dá falha).
                temporada = _mapper.Map(temporadaModelo, temporada);

                //Efetiva a atualização.
                _temporadaRepositorio.Atualizar(temporada);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverTemporada(int id)
        {
            try
            {
                Temporada temporada = _temporadaRepositorio.Obter(id);
                if (temporada == null)
                    return NotFound();

                _temporadaRepositorio.Remover(temporada);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpOptions]
        public IActionResult ListarOperacoesPermitidas()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
            return Ok();
        }
    }
}
