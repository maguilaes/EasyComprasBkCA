using MediatR;

namespace Application.Clientes.Queries.GetClientes
{
    public class GetClienteQuery : IRequest<List<ClientesVM>>
    {
    }
}
