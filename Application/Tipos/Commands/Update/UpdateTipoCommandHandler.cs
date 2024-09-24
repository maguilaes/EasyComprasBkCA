using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Tipos.Commands.Update
{
    public class UpdateTipoCommandHandler : IRequestHandler<UpdateTipoCommand, int>
    {
        private readonly ITipoRepository _tipoRepository;

        public UpdateTipoCommandHandler(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }
        public async Task<int> Handle(UpdateTipoCommand request, CancellationToken cancellationToken)
        {
            var UpdateTipoEntity = new BaseTipos()
            {
                Id = request.Id,
                Descripcion = request.Descripcion,
                Estado = request.Estado
            };

            return await _tipoRepository.UpdateAsync(request.Id, UpdateTipoEntity);
        }
    }
}
