using Application.DTOs;
using AutoMapper;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Queries.GetProductos
{
    public class GetProductoEmpresaQueryHandler : IRequestHandler<GetProductoQuery, List<ProductosDto>>
    {
        private readonly IProductoRepository _entityRepository;
        private readonly ICiudadRepository _ciudadRepository;
        private readonly ISucursalRepository _sucursalRepository;
        private readonly IClasificadorRepository _clasificadorRepository;
        private readonly IMapper _mapper;

        public GetProductoEmpresaQueryHandler(IProductoRepository entityRepository, IMapper mapper,
            ISucursalRepository sucursalRepository, IClasificadorRepository clasificadorRepository, ICiudadRepository ciudadRepository)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
            _clasificadorRepository = clasificadorRepository;
            _sucursalRepository = sucursalRepository;
            _ciudadRepository = ciudadRepository;
        }
        public async Task<List<ProductosDto>> Handle(GetProductoQuery request, CancellationToken cancellationToken)
        {
            var cid = await _ciudadRepository.GetAllAsync();
            var med = await _clasificadorRepository.GetByTipoIdAsync(2);
            var prod = await _entityRepository.GetAllAsync();
            var suc = await _sucursalRepository.GetAllAsync();
            var cat = await _clasificadorRepository.GetAllAsync();
            
            var prodDto = (from p in prod
                           join s in suc on p.IdSucursal equals s.Id
                           join ci in cid on s.IdcCiudad equals ci.Id
                           join c in cat on p.IdcCategoria equals c.Id
                           join m in med on p.IdcMedida equals m.Id
                           select new
                           {
                               p.Id,
                               ci.Ciudad,
                               CiudadId = ci.Id,
                               Sucursal= s.NombreSucursal,
                               p.IdSucursal,
                               Categoria= c.Descripcion,
                               p.IdcCategoria,
                               p.Codigo,
                               p.NombreProducto,
                               p.Descripcion,
                               p.Stock,
                               Medida = m.Descripcion,
                               p.IdcMedida,
                               p.PrecioCompra,
                               p.PrecioVenta,
                               p.UrlImagen,
                               p.Estado
                           }).ToList();

            List<ProductosDto> listData = new List<ProductosDto>();
            foreach (var item in prodDto)
            {
                ProductosDto dto = new ProductosDto();
                dto.Id = item.Id;
                dto.CiudadOrigen = item.Ciudad;
                dto.CiudadId = item.CiudadId;
                dto.Sucursal = item.Sucursal;
                dto.SucursalId = item.IdSucursal;
                dto.Categoria = item.Categoria;
                dto.CategoriaId = item.IdcCategoria;
                dto.Codigo = item.Codigo;
                dto.Nombre = item.NombreProducto;
                dto.Descripcion = item.Descripcion;
                dto.Stock = item.Stock;
                dto.Medida = item.Medida;
                dto.IdcMedida = item.IdcMedida;
                dto.PrecioCompra = item.PrecioCompra;
                dto.PrecioVenta = item.PrecioVenta;
                dto.UrlImagen = item.UrlImagen;
                dto.Estado = item.Estado;
                listData.Add(dto);
            }

            var dataDto = _mapper.Map<List<ProductosDto>>(listData);
            return dataDto;
        }
    }
}
