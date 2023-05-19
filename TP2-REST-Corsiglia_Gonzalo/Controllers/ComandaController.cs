using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP2_REST_Corsiglia_Gonzalo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaServices _comandaService;

        public ComandaController(IComandaServices comandaService)
        {
            _comandaService = comandaService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComandaGetResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequest))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BadRequest))]
        public async Task<IActionResult> GetComandaById(Guid comandaId)
        {
            var result = await _comandaService.GetComandaById(comandaId);
            if (result == null)
            {
                return NotFound(new { message = "No se encontro la comanda" });
            }

            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetComandas(DateTime fecha)
        {
            var result = await _comandaService.GetComandas(fecha);

            if (result == null)
            {
                return NotFound(new { message = "No se encontraron comandas" });
            }

            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPost]
        [ProducesResponseType(typeof(Comanda), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateComanda(ComandaRequest request)
        {
            var result = await _comandaService.CreateComanda(request);

            if (result == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };
        }
        
    }
}
