using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exemplo1.Controllers
{
    /// <summary>
    /// A herança de 'controllerbase' indica o utilização do recurso básico para utilização da entidade como
    /// um 'controller'. Casos em que o asp.net é utilizado no frontend, a herança seria de 'controller'.
    /// </summary>
    [ApiController]
    //[Route("api/[controller]")] - Reza que a boa prática pede para especificar o nome (por isso logo abaixo).
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok("Todos os produtos.");
        }
    }
}
