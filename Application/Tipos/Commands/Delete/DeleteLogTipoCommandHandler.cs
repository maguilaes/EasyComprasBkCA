using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Tipos.Commands.Delete
{
    public class DeleteLogTipoCommandHandler : IRequestHandler<DeleteLogTipoCommand, int>
    {
        private readonly ITipoRepository _datRepository;

        public DeleteLogTipoCommandHandler(ITipoRepository datRepository)
        {
            _datRepository = datRepository;
        }
        public async Task<int> Handle(DeleteLogTipoCommand request, CancellationToken cancellationToken)
        {
            var UpdateTipoEntity = new BaseTipos()
            {
                Id = request.Id,
                Estado = false
            };

            return await _datRepository.UpdateAsync(request.Id, UpdateTipoEntity);
        }
    }
}
