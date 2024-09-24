using MediatR;

namespace Application.Configs.Commands.Update
{
    public class UpdateConfigCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Recurso { get; set; }
        public string? Propiedad { get; set; }
        public string? Valor { get; set; }
        public bool Estado { get; set; }
    }
}
