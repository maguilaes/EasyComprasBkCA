using MediatR;

namespace Application.Usuarios.Queries.GetUsuarios
{
    public class GetUsuarioQuery : IRequest<List<UsuariosVM>>
    {
    }
}
