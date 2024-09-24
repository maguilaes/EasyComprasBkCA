using MediatR;

namespace Application.Sucursales.Commands.Delete
{
    public class DeleteLogSucursalCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
