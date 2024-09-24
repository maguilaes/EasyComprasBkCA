using Domain.Entity;

namespace Application.Interface
{
    public interface ICorreoService
    {
        void SendEmail(IniEmail request);

        Task<bool> EnviarCorreo(string AliasOrigen, string CorreoDestino, string Asunto, string Mensaje);
    }
}
