using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Clasificadores.Commands.Update
{
    public class UpdateClasificadorCommandHandler : IRequestHandler<UpdateClasificadorCommand, int>
    {
        private readonly IClasificadorRepository _repository;

        public UpdateClasificadorCommandHandler(IClasificadorRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(UpdateClasificadorCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new BaseClasificadores()
            {
                Id = request.Id,
                Descripcion = request.Descripcion,
                Estado = request.Estado,
                IdTipo = request.IdTipo
            };

            return await _repository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
