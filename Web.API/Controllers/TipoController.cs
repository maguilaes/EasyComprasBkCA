using Application.Tipos.Commands.Create;
using Application.Tipos.Commands.Delete;
using Application.Tipos.Commands.Update;
using Application.Tipos.Queries.GetTipoById;
using Application.Tipos.Queries.GetTipos;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetTipoQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetTipoByIdQuery() { TipoId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTipoCommand command)
        {
            var createdObj = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdObj.Id }, createdObj);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTipoCommand command)
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
            var result = await Mediator.Send(new DeleteLogTipoCommand { Id = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
