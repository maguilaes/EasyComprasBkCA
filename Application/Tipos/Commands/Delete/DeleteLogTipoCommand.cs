using MediatR;

namespace Application.Tipos.Commands.Delete
{
    public class DeleteLogTipoCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
