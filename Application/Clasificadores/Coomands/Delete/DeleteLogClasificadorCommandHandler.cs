using Domain.Repository;
using MediatR;

namespace Application.Clasificadores.Coomands.Delete
{
    public class DeleteLogClasificadorCommandHandler : IRequestHandler<DeleteLogClasificadorCommand, int>
    {
        private readonly IClasificadorRepository _datRepository;

        public DeleteLogClasificadorCommandHandler(IClasificadorRepository datRepository)
        {
            _datRepository = datRepository;
        }
        public async Task<int> Handle(DeleteLogClasificadorCommand request, CancellationToken cancellationToken)
        {
            return await _datRepository.DeleteAsync(request.Id);
        }
    }
}
