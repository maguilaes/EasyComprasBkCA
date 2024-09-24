using Application.Clientes.Queries.GetClientes;
using MediatR;

namespace Application.Clientes.Queries.GetClienteById
{
    public class GetClienteByIdQuery : IRequest<ClientesVM>
    {
        public int ClienteId { get; set; }
    }
}
