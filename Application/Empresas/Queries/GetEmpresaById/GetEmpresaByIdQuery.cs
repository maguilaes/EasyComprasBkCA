using Application.Empresas.Queries.GetEmpresas;
using MediatR;

namespace Application.Empresas.Queries.GetEmpresaById
{
    public class GetEmpresaByIdQuery : IRequest<EmpresasVM>
    {
        public int EmpresaId { get; set; }
    }
}
