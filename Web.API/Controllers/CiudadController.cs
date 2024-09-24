using Application.Ciudades.Commands.Create;
using Application.Ciudades.Commands.Delete;
using Application.Ciudades.Commands.Update;
using Application.Ciudades.Queries.GetCiudadById;
using Application.Ciudades.Queries.GetCiudades;
using Application.Sucursales.Commands.Create;
using Application.Sucursales.Commands.Delete;
using Application.Sucursales.Commands.Update;
using Application.Sucursales.Queries.GetSucursalById;
using Application.Sucursales.Queries.GetSucursales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShop.API.Controllers
{
    [ApiVersion("1.0")]
    public class CiudadController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetCiudadQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetCiudadByIdQuery() { CiudadId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCiudadCommand command)
        {
            var createdObj = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdObj.Id }, createdObj);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCiudadCommand command)
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
            var result = await Mediator.Send(new DeleteLogCiudadCommand { Id = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
