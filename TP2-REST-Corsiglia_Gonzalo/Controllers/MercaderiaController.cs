using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace TP2_REST_Corsiglia_Gonzalo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercaderiaController : ControllerBase
    {
        private readonly IMercaderiaServices _mercaderiaService;

        public MercaderiaController(IMercaderiaServices mercaderiaService)
        {
            _mercaderiaService = mercaderiaService;
        }

        [HttpGet("/api/v1/Mercaderia/{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetMercaderiaById([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { message = "El valor del parámetro id no es válido" });
            }

            var result = await _mercaderiaService.GetMercaderiaById(id);

            if (result == null)
            {
                return NotFound(new { message = "No se encontró la mercadería" });
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> DeleteMercaderia(int id)
        {
            var result = await _mercaderiaService.DeleteMercaderia(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMercaderia(MercaderiaRequest request)
        {
            var result = await _mercaderiaService.CreateMercaderia(request);
            if(result == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return new JsonResult(result) { StatusCode = StatusCodes.Status201Created } ;
        }

        [HttpPut("mercaderia/{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMercaderia(int mercaderiaId, MercaderiaRequest request)
        {
            var result = await _mercaderiaService.UpdateMercaderia(mercaderiaId, request);
            if(result == null)
            {
                return NotFound(new { message = "No se encontro la mercaderia" });
            }
            return new JsonResult(result) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("/api/v1/Mercaderia")]
        [ProducesResponseType(typeof(IEnumerable<MercaderiaGetResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequest), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMercaderias(int tipo, string? nombre, string orden = "ASC") 
        {
            var result = await _mercaderiaService.GetMercaderias(tipo, nombre, orden);

            if(result == null) 
            {
                return NotFound(new { message = "No se encontraron mercaderias" });
            }

            return Ok(result);
        }
    }

        
}
