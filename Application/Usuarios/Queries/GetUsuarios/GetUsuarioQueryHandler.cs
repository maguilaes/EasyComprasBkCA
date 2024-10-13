using Application.DTOs;
using AutoMapper;
using Domain.Repository;
using MediatR;
using MimeKit.Cryptography;

namespace Application.Usuarios.Queries.GetUsuarios
{
    public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, List<UsuarioDto>>
    {
        private readonly IUsuarioRepository _entityRepository;
        private readonly IClasificadorRepository _clasificadorRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IMapper _mapper;

        public GetUsuarioQueryHandler(IUsuarioRepository entityRepository, IMapper mapper, IClasificadorRepository clasificadorRepository, IEmpresaRepository empresaRepository, ISucursalRepository sucursalRepository)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
            _clasificadorRepository = clasificadorRepository;
            _empresaRepository = empresaRepository;
            _sucursalRepository = sucursalRepository;
        }
        public async Task<List<UsuarioDto>> Handle(GetUsuarioQuery request, CancellationToken cancellationToken)
        {
            var roles = await _clasificadorRepository.GetByTipoIdAsync(1);
            var emp = await _empresaRepository.GetAllAsync();
            var suc = await _sucursalRepository.GetAllAsync();
            var user = await _entityRepository.GetAllAsync();

            var usrRel = (from u in user
                          join e in emp on u.IdEmpresa equals e.Id
                          join s in suc on u.IdSucursal equals s.Id
                          join r in roles on u.IdcRol equals r.Id
                          select new 
                          { 
                             u.Id,
                             u.NombreCompleto,
                             u.Email,
                             u.Clave,
                             Privilegio = r.Descripcion,
                             u.IdcRol,
                             Empresa = e.NombreEmpresa,
                             u.IdEmpresa,
                             Sucursal = s.NombreSucursal,
                             u.IdSucursal,
                             u.Estado
                          }).ToList();

            List<UsuarioDto> listData = new List<UsuarioDto>();
            foreach (var item in usrRel)
            {
                UsuarioDto dto = new UsuarioDto();
                dto.Id = item.Id;
                dto.NombreCompleto = item.NombreCompleto;
                dto.Email = item.Email;
                dto.Clave = item.Clave;
                dto.Privilegios = item.Privilegio;
                dto.IdcRol = item.IdcRol;
                dto.Empresa = item.Empresa;
                dto.IdEmpresa = item.IdEmpresa;
                dto.Sucursal = item.Sucursal;
                dto.IdSucursal = item.IdSucursal;
                dto.Estado = item.Estado;                
                listData.Add(dto);
            }

            var dataDto = _mapper.Map<List<UsuarioDto>>(listData);
            return dataDto;
        }
    }
}
