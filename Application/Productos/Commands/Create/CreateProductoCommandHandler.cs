using Application.Productos.Queries.GetProductos;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Commands.Create;

public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, ProductosVM>
{
    private readonly IProductoRepository _entityRepository;
    private readonly IFireBaseService _firebaseService;
    private readonly IMapper _mapper;

    public CreateProductoCommandHandler(IProductoRepository entityRepository, IMapper mapper, IFireBaseService firebaseService)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
        _firebaseService = firebaseService;
    }

    public async Task<ProductosVM> Handle(CreateProductoCommand command, CancellationToken cancellationToken)
    {
        #region SUBIR IMAGEN A STORAGE
        string nombreImagen = command.UrlImagen.FileName;
        string nombreImagenExtension = string.Empty;
        //Stream imagenStream = null;

        if (command.UrlImagen != null)
        {
            //string nombre_en_codigo = Guid.NewGuid().ToString("N");
            string extension = Path.GetExtension(command.UrlImagen.FileName);
            string nombreSinExtension = Path.GetFileNameWithoutExtension(command.UrlImagen.FileName);
            nombreImagenExtension = string.Concat(nombreSinExtension, extension);
            //imagenStream = Imagen.OpenReadStream();
        }

        Stream imagen = command.UrlImagen.OpenReadStream();
        var urlImagen = await _firebaseService.SubirStorage(imagen, command.NombreEmpresa, "IMG_PRODUCTO", nombreImagenExtension);
        #endregion

        if(urlImagen == null)
        {
            urlImagen = "SinImagen";
        }
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
            UrlImagen = urlImagen.ToString(),
            Estado = command.Estado,
            IdUsuarioRegistro = command.IdUsuarioRegistro,
            FechaRegistro = DateTime.Now.Date
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<ProductosVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.NombreProducto}");
    }
}

