using Application.Sucursales.Commands.Create;
using Application.Sucursales.Commands.Delete;
using Application.Sucursales.Commands.Update;
using Application.Sucursales.Queries.GetSucursalById;
using Application.Sucursales.Queries.GetSucursales;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShop.API.Controllers
{
    [ApiVersion("1.0")]
    public class SucursalController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetSucursalQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetSucursalByIdQuery() { SucursalId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSucursalCommand command)
        {
            var createdObj = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdObj.Id }, createdObj);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSucursalCommand command)
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
            var result = await Mediator.Send(new DeleteLogSucursalCommand { Id = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
