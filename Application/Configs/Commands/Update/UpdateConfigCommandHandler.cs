using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Configs.Commands.Update
{
    public class UpdateConfigCommandHandler : IRequestHandler<UpdateConfigCommand, int>
    {
        private readonly IConfigRepository _entityRepository;

        public UpdateConfigCommandHandler(IConfigRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<int> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
        {
            var UpdateEntity = new IniConfig()
            {
                Id = request.Id,
                Recurso = request.Recurso,
                Propiedad = request.Propiedad,
                Valor = request.Valor,
                Estado = request.Estado
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
