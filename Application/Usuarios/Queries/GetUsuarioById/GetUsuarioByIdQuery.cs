using Application.Usuarios.Queries.GetUsuarios;
using MediatR;

namespace Application.Usuarios.Queries.GetUsuarioById
{
    public class GetUsuarioByIdQuery : IRequest<UsuariosVM>
    {
        public int UsuarioId { get; set; }
    }
}
