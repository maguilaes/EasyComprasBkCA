using MediatR;

namespace Application.Tipos.Commands.Update
{
    public class UpdateTipoCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
