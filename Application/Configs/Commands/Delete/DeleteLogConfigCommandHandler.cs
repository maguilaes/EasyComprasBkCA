using Domain.Entity;
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
            var UpdateEntity = new IniConfig()
            {
                Id = request.Id,
                Estado = false
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
