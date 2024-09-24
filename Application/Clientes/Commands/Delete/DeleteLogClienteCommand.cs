using MediatR;

namespace Application.Clientes.Commands.Delete
{
    public class DeleteLogClienteCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
