using MediatR;

namespace Application.Ciudades.Commands.Delete
{
    public class DeleteLogCiudadCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
