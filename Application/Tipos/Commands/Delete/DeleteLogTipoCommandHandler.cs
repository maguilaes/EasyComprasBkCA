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
            return await _datRepository.DeleteAsync(request.Id);
        }
    }
}
