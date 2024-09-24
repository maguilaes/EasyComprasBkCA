using Application.Productos.Queries.GetProductos;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Commands.Create;

public class CreateEmpresaCommandHandler : IRequestHandler<CreateProductoCommand, ProductosVM>
{
    private readonly IProductoRepository _entityRepository;
    private readonly IMapper _mapper;

    public CreateEmpresaCommandHandler(IProductoRepository entityRepository, IMapper mapper)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
    }

    public async Task<ProductosVM> Handle(CreateProductoCommand command, CancellationToken cancellationToken)
    {
        var data = new NegProductos
        {
            IdSucursal = command.IdSucursal,
            IdcMedida = command.IdcMedida,
            IdcCategoria = command.IdcCategoria,
            Codigo = command.Codigo,
            NombreProducto = command.NombreProducto,
            Descripcion = command.Descripcion,
            Stock = command.Stock,
            PrecioCompra = command.PrecioCompra,
            PrecioVenta = command.PrecioVenta,
            UrlImagen = command.UrlImagen,
            Estado = command.Estado,
            IdUsuarioRegistro = command.IdUsuarioRegistro,
            FechaRegistro = DateTime.UtcNow
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<ProductosVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.NombreProducto}");
    }
}

