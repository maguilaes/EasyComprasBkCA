using MediatR;

namespace Application.Productos.Commands.Delete
{
    public class DeleteLogProductoCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
