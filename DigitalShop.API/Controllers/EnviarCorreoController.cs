using Application.Ciudades.Commands.Create;
using Domain.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalShop.API.Controllers
{
    [ApiVersion("1.0")]
    public class EnviarCorreoController : BaseApiController
    {
        private readonly ICorreoService _repository;
        public EnviarCorreoController(ICorreoService repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<bool> EnviarCorreo(string AliasOrigen, string CorreoDestino, string Asunto, string Mensaje)
        {
            return await _repository.EnviarCorreo(AliasOrigen, CorreoDestino, Asunto, Mensaje);
        }
    }
}
