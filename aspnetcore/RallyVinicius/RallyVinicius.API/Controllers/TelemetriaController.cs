using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RallyVinicius.API.Modelo;
using RallyVinicius.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyVinicius.API.Controllers
{
    [ApiController]
    [Route("api/equipes/{equipeId}/telemetria")]
    public class TelemetriaController : ControllerBase
    {
        private readonly ITelemetriaRepositorio _telemetriaRepositorio;        
        private readonly IMapper _mapper;
        private readonly ILogger<TelemetriaController> _logger;
        private readonly IEquipeRepositorio _equipeRepositorio;

        public TelemetriaController(ITelemetriaRepositorio telemetriaRepositorio, IMapper mapper, 
                                    ILogger<TelemetriaController> logger, IEquipeRepositorio equipeRepositorio)
        {
            _telemetriaRepositorio = telemetriaRepositorio;
            _mapper = mapper;
            _logger = logger;
            _equipeRepositorio = equipeRepositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TelemetriaModelo>> Obter(int equipeId)
        {
            try
            {
                if (!_equipeRepositorio.Existe(equipeId))
                    return NotFound();

                var dadosTelemetria = _telemetriaRepositorio.ObterTodosPorEquipe(equipeId);

                if (!dadosTelemetria.Any())
                    return NotFound($"Não foram retornados dados de telemetria para a equipe informada: {equipeId}");
                   
                var dadosTelemetriaModelo = _mapper.Map<IEnumerable<TelemetriaModelo>>(dadosTelemetria);
                return Ok(dadosTelemetriaModelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }
    }
}
