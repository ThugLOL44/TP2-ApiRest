using Application.Exceptions;
using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

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
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public async Task<IActionResult> GetMercaderiaById(int id)
        {
            try
            {
                if (!int.TryParse(id.ToString(), out _))
                {
                    throw new BadRequestException("El formato de id ingresado es invalido");
                }

                var result = await _mercaderiaService.GetMercaderiaById(id);

                return Ok(result);
            }
            catch(NotFoundException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 404 };
            }
            catch (BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpDelete("/api/v1/Mercaderia/{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> DeleteMercaderia(int id)
        {
            try
            {
                if (!int.TryParse(id.ToString(), out _))
                {
                    throw new BadRequestException("El formato de id ingresado es invalido");
                }

                var result = await _mercaderiaService.DeleteMercaderia(id);
                return Ok(result);
            }
            catch (HasConflictException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 409 };
            }
            catch (BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
            catch (NotFoundException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 404 };
            }

        }

        [HttpPost("/api/v1/Mercaderia")]
        [ProducesResponseType(typeof(MercaderiaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> CreateMercaderia(MercaderiaRequest request)
        {
            try
            {
                var result = await _mercaderiaService.CreateMercaderia(request);
                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };

            } catch (HasConflictException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 409 };
            }
            catch (SyntaxErrorException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPut("/api/v1/Merecaderia/{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public async Task<IActionResult> UpdateMercaderia(int id, MercaderiaRequest request)
        {
            try
            {
                if (!int.TryParse(id.ToString(), out _))
                {
                    throw new BadRequestException("El formato de id ingresado es invalido");
                }

                var result = await _mercaderiaService.UpdateMercaderia(id, request);
                return Ok(result);
            }catch(NotFoundException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 404 };
            }
            catch(HasConflictException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }) { StatusCode = 409 };
            }
        }

        [HttpGet("/api/v1/Mercaderia")]
        [ProducesResponseType(typeof(IEnumerable<MercaderiaGetResponse>),200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public async Task<IActionResult> GetMercaderias(int tipo, string? nombre, string? orden = "ASC") 
        {
            try
            {
                var result = await _mercaderiaService.GetMercaderias(tipo, nombre, orden);
                return Ok(result);
            }catch(BadRequestException ex)
            {
                return new JsonResult(new BadRequest { message = ex.Message }){ StatusCode = 400 };
            }
        }
    }

        
}
