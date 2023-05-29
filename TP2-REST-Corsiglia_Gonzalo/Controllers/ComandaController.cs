using Application.Exceptions;
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

        [HttpGet("/api/v1/Comanda/{id}")]
        [ProducesResponseType(typeof(ComandaGetResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetComandaById(Guid id)
        {
            try
            {
                var result = await _comandaService.GetComandaById(id);
                return Ok(result);
            }
            catch(NotFoundException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }){ StatusCode = 404 };
            }
            catch(BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/v1/Comanda")]
        [ProducesResponseType(typeof(IEnumerable<ComandaResponse>), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public async Task<IActionResult> GetComandas(string fecha)
        {
            try
            {
                var result = await _comandaService.GetComandas(fecha);
                return Ok(result);
            }
            catch(BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/v1/Comanda")]
        [ProducesResponseType(typeof(ComandaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public async Task<IActionResult> CreateComanda(ComandaRequest request)
        {
            try
            {
                var result = await _comandaService.CreateComanda(request);

                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };
            }catch(BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
        }
        
    }
}
