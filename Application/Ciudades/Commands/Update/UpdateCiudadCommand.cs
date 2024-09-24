using MediatR;

namespace Application.Ciudades.Commands.Update
{
    public class UpdateCiudadCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Ciudad { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public int IdcPais { get; set; }
    }
}
