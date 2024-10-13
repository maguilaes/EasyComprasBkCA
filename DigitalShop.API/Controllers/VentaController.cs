using Application.Tipos.Queries.GetTipoById;
using Application.Ventas.Commands.Create;
using Application.Ventas.Queries.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DigitalShop.API.Controllers
{
    [ApiVersion("1.0")]
    public class VentaController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetVentaByIdQuery() { VentaId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateVentaCommand data)
        {
            var createdObj = await Mediator.Send(data);
            return CreatedAtAction(nameof(GetById), new { id = createdObj.Id }, createdObj);
        }
        //[HttpDelete("DeleteLogicoVentaId")]
        //public async Task<IActionResult> DeleteLogicoVentaId(int idVenta)
        //{
        //    return Ok(await _mediator.Send(new DeleteLogicoVentaCommand { VentaId = idVenta }));
        //}
    }
}
