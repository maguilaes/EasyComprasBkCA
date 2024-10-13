using Application.Direcciones.Commands.Create;
using Application.Direcciones.Commands.Delete;
using Application.Direcciones.Commands.Update;
using Application.Direcciones.Queries.GetDireccionById;
using Application.Direcciones.Queries.GetDireccionByPaisCiudadId;
using Application.Direcciones.Queries.GetDireccionByRelacionId;
using Application.Direcciones.Queries.GetDirecciones;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShop.API.Controllers
{
    [ApiVersion("1.0")]
    public class DireccionController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetDireccionQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetDireccionByIdQuery() { DireccionId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpGet("{idrelacion}")]
        public async Task<IActionResult> GetDireccionByRelacionIdQuery(string idrelacion)
        {
            var blog = await Mediator.Send(new GetDireccionByRelacionIdQuery() { RelacionId = idrelacion });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpGet("{idpais,idciudad}")]
        public async Task<IActionResult> GetDireccionByRelacionIdQuery(int idpais, int idciudad)
        {
            var blog = await Mediator.Send(new GetDireccionByPaisCiudadIdQuery() { PaisId = idpais, CiudadId = idciudad });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDireccionCommand command)
        {
            var createdObj = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdObj.Id }, createdObj);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDireccionCommand command)
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
            var result = await Mediator.Send(new DeleteLogDireccionCommand { Id = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
