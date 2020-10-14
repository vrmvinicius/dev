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
    [Route("api/pilotos")] //Pluralização do nome.
    public class PilotoController : ControllerBase
    {
        //Ambos recebem suas instâncias via 'injeção de dependência'.
        private readonly IPilotoRepositorio _pilotoRepositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<PilotoController> _logger;

        public PilotoController(IPilotoRepositorio pilotoRepositorio, IMapper mapper, ILogger<PilotoController> logger)
        {
            _pilotoRepositorio = pilotoRepositorio;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id}", Name="Obter")]
        public IActionResult Obter(int id)
        {
            try
            {
                var piloto = _pilotoRepositorio.Obter(id);
                
                if (piloto == null)
                    return NotFound();

                var pilotoModelo = _mapper.Map<PilotoModelo>(piloto);

                return Ok(pilotoModelo);
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString()); //Logando as falhas.
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPost]
        public IActionResult AdicionarPiloto([FromBody] PilotoModelo pilotoModelo)
        {
            try
            {
                _logger.LogInformation("Adicionando um piloto..");

                //Repassa do modelo para a entidade de domínio de forma automatica.
                var piloto = _mapper.Map<Piloto>(pilotoModelo);
                
                if (_pilotoRepositorio.Existe(piloto.Id))
                    return StatusCode(409, "Já existe um piloto cadastrado com esta identificação");

                _pilotoRepositorio.Adicionar(piloto);

                var pilotoModeloRetorno = _mapper.Map<PilotoModelo>(piloto);

                //Retorna o caminho completo do 'recurso' relacionado ao novo piloto inserido e o objeto de modelo vinculado.
                return CreatedAtRoute("Obter", new { id = piloto.Id }, pilotoModeloRetorno);
            }
            catch (Exception ex)
            {
                //_logger.Info(ex.ToString()); //Logando as falhas.
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }                        
        }

        [HttpPut]
        public IActionResult AtualizarPiloto([FromBody] PilotoModelo pilotoModelo)
        {
            try
            {                
                var piloto = _mapper.Map<Piloto>(pilotoModelo);

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

        [HttpPatch("{id}")]
        public IActionResult AtualizarParcialmentePiloto(int id, [FromBody] JsonPatchDocument<PilotoModelo> patchPilotoModelo)
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
                if (!_pilotoRepositorio.Existe(id))
                    return NotFound();
                
                //Obtém o objeto monitorado do Entity Framework da base.
                var piloto = _pilotoRepositorio.Obter(id);
                //Gera uma instância do objeto de negócio para o objeto de modelo.
                var pilotoModelo = _mapper.Map<PilotoModelo>(piloto);

                //Aplica as alterações do modelo.
                patchPilotoModelo.ApplyTo(pilotoModelo);
                //Mapeia no objeto retornado anteriormente pelo entity framework (aqui não pode gerar nova instância se não dá falha).
                piloto = _mapper.Map(pilotoModelo, piloto);
                                
                //Efetiva a atualização.
                _pilotoRepositorio.Atualizar(piloto);
                
                return NoContent();
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

        [HttpOptions]
        public IActionResult ListarOperacoesPermitidas()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
            return Ok();
        }
    }
}
