using Application.Sucursales.Queries.GetSucursales;
using MediatR;

namespace Application.Sucursales.Queries.GetSucursalById
{
    public class GetSucursalByIdQuery : IRequest<SucursalesVM>
    {
        public int SucursalId { get; set; }
    }
}
