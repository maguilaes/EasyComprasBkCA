using MediatR;

namespace Application.Usuarios.Commands.Delete
{
    public class DeleteLogUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
