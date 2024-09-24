using MediatR;

namespace Application.Empresas.Commands.Delete
{
    public class DeleteLogEmpresaCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
