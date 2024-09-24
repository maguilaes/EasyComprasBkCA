using MediatR;

namespace Application.Empresas.Queries.GetEmpresas
{
    public class GetEmpresaQuery : IRequest<List<EmpresasVM>>
    {
    }
}
