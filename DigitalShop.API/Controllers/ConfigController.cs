using Application.Clasificadores.Commands.Update;
using Application.Clasificadores.Coomands.Create;
using Application.Clasificadores.Coomands.Delete;
using Application.Clasificadores.Queries.GetClasificadorById;
using Application.Clasificadores.Queries.GetClasificadorByTipoId;
using Application.Clasificadores.Queries.GetClasificadores;
using Application.Configs.Commands.Create;
using Application.Configs.Commands.Delete;
using Application.Configs.Commands.Update;
using Application.Configs.Queries.GetConfigById;
using Application.Configs.Queries.GetConfigs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShop.API.Controllers
{
    [ApiVersion("1.0")]
    public class ConfigController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await Mediator.Send(new GetConfigQuery());
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await Mediator.Send(new GetConfigByIdQuery() { ConfigId = id });
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        //[HttpGet("{idtipo}")]
        //public async Task<IActionResult> GetByTipoId(int idtipo)
        //{
        //    var blog = await Mediator.Send(new GetClasificadorByTipoIdQuery() { TipoId = idtipo });
        //    if (blog == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(blog);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(CreateConfigCommand command)
        {
            var createdObj = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdObj.Id }, createdObj);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateConfigCommand command)
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
            var result = await Mediator.Send(new DeleteLogConfigCommand { Id = id });
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
