using MediatR;

namespace Application.Configs.Commands.Delete
{
    public class DeleteLogConfigCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
