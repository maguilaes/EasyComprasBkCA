using Application.Productos.Commands.Create;
using Application.Productos.Commands.Delete;
using Application.Productos.Commands.Update;
using Application.Productos.Queries.GetProductoById;
using Application.Productos.Queries.GetProductos;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShop.API.Controllers
{
    [ApiVersion("1.0")]
    public class ProductoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetProductoQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetProductoByIdQuery() { ProductoId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductoCommand command)
        {
            var createdObj = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdObj.Id }, createdObj);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductoCommand command)
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
            var result = await Mediator.Send(new DeleteLogProductoCommand { Id = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
