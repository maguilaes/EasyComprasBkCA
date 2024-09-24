using MediatR;

namespace Application.Clasificadores.Coomands.Delete
{
    public class DeleteLogClasificadorCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
