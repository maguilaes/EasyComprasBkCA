using Application.DTOs;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Clasificadores.Queries.GetClasificadores
{
    public class GetClasificadorQueryHandler : IRequestHandler<GetClasificadorQuery, List<ClasficadorDto>>
    {
        private readonly IClasificadorRepository _dataRepository;
        private readonly ITipoRepository _tipoRepository;
        private readonly IMapper _mapper;

        public GetClasificadorQueryHandler(IClasificadorRepository dataRepository, IMapper mapper, ITipoRepository tipoRepository)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
            _tipoRepository = tipoRepository;
        }
        public async Task<List<ClasficadorDto>> Handle(GetClasificadorQuery request, CancellationToken cancellationToken)
        {
            var tipo = await _tipoRepository.GetAllAsync();
            var res = await _dataRepository.GetAllAsync();

            var dto = (from r in res
                       join t in tipo on r.IdTipo equals t.Id
                       select new
                       {
                           r.Id,
                           r.Descripcion,
                           TipoClasificador = t.Descripcion,
                           r.IdTipo
                       }).ToList();

            List<ClasficadorDto> listData = new List<ClasficadorDto>();
            foreach(var item in dto)
            {
                ClasficadorDto tbl = new ClasficadorDto();
                tbl.Id = item.Id;
                tbl.Descripcion = item.Descripcion;
                tbl.TipoClasificador = item.TipoClasificador;
                tbl.IdTipo = item.IdTipo;
                listData.Add(tbl);
            }

            var solDto = _mapper.Map<List<ClasficadorDto>>(listData);
            return solDto;
        }
    }
}
