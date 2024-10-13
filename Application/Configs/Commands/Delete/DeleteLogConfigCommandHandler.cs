using Domain.Repository;
using MediatR;

namespace Application.Configs.Commands.Delete
{
    public class DeleteLogConfigCommandHandler : IRequestHandler<DeleteLogConfigCommand, int>
    {
        private readonly IConfigRepository _entityRepository;

        public DeleteLogConfigCommandHandler(IConfigRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(DeleteLogConfigCommand request, CancellationToken cancellationToken)
        {
            return await _entityRepository.DeleteAsync(request.Id);
        }
    }
}
