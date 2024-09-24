using Domain.Entity;
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
            var UpdateDataEntity = new BaseClasificadores()
            {
                Id = request.Id,
                Estado = false
            };

            return await _datRepository.UpdateAsync(request.Id, UpdateDataEntity);
        }
    }
}
