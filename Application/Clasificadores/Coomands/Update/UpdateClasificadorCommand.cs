using MediatR;

namespace Application.Clasificadores.Commands.Update
{
    public class UpdateClasificadorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int IdTipo { get; set; }
    }
}
