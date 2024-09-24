using MediatR;

namespace Application.Direcciones.Commands.Delete
{
    public class DeleteLogDireccionCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
