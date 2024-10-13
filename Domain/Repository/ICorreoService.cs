using Domain.Entity;

namespace Domain.Repository
{
    public interface ICorreoService
    {
        Task<bool> EnviarCorreo(string AliasOrigen, string CorreoDestino, string Asunto, string Mensaje);
    }
}
