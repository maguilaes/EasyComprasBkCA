using Application.Ciudades.Commands.Create;
using Application.Ciudades.Commands.Delete;
using Application.Ciudades.Commands.Update;
using Application.Ciudades.Queries.GetCiudadById;
using Application.Ciudades.Queries.GetCiudadByPaisId;
using Application.Ciudades.Queries.GetCiudades;
using Application.CuentaPagos.Commands.Create;
using Application.CuentaPagos.Commands.Delete;
using Application.CuentaPagos.Commands.Update;
using Application.CuentaPagos.Queries.GetCuentaPagos;
using Application.CuentaPagos.Queries.GetCuentaPagosById;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShop.API.Controllers
{
    [ApiVersion("1.0")]
    public class CuentaPagoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetCuentaPagoQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetCuentaPagoByIdQuery() { CuentaPagoId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCuentaPagoCommand command)
        {
            var createdObj = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdObj.Id }, createdObj);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCuentaPagoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteLogCuentaPagoCommand { Id = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
