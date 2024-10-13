using Application.Tipos.Queries.GetTipoById;
using Application.Tipos.Queries.GetTipos;
using Application.Ventas.Queries.GetVentas;
using AutoMapper;
using Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ventas.Queries.GetById
{
    public class GetVentaByIdQueryHandler : IRequestHandler<GetVentaByIdQuery, VentasVM>
    {
        private readonly IVentaRepository _entityRepository;
        private readonly IMapper _mapper;

        public GetVentaByIdQueryHandler(IVentaRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }
        public async Task<VentasVM> Handle(GetVentaByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _entityRepository.GetByIdAsync(request.VentaId);
            return _mapper.Map<VentasVM>(data);
        }
    }
}
