using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Productos.Commands.Update
{
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, int>
    {
        private readonly IProductoRepository _entityRepository;
        private readonly IFireBaseService _firebaseService;

        public UpdateProductoCommandHandler(IProductoRepository entityRepository, IFireBaseService firebaseService)
        {
            _entityRepository = entityRepository;
            _firebaseService = firebaseService;
        }
        public async Task<int> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            #region SUBIR IMAGEN A STORAGE
            string nombreImagen = request.UrlImagen.FileName;
            string nombreImagenExtension = string.Empty;
            //Stream imagenStream = null;

            if (request.UrlImagen != null)
            {
                //string nombre_en_codigo = Guid.NewGuid().ToString("N");
                string extension = Path.GetExtension(request.UrlImagen.FileName);
                string nombreSinExtension = Path.GetFileNameWithoutExtension(request.UrlImagen.FileName);
                nombreImagenExtension = string.Concat(nombreSinExtension, extension);
                //imagenStream = Imagen.OpenReadStream();
            }

            Stream imagen = request.UrlImagen.OpenReadStream();
            var urlImagen = await _firebaseService.SubirStorage(imagen, request.NombreEmpresa, "IMG_PRODUCTO", nombreImagenExtension);
            #endregion

            if (urlImagen == null)
            {
                urlImagen = "SinImagen";
            }
            var UpdateEntity = new NegProductos()
            {
                //Id = request.Id,
                IdSucursal = request.IdSucursal,
                IdcCategoria = request.IdcCategoria,
                Codigo = request.Codigo,
                NombreProducto = request.NombreProducto,
                Descripcion = request.Descripcion,
                Stock = request.Stock,
                IdcMedida = request.IdcMedida,
                PrecioCompra  = request.PrecioCompra,
                PrecioVenta = request.PrecioVenta,
                UrlImagen = urlImagen.ToString(),
                Estado = request.Estado,
                IdUsuarioModificacion = request.IdUsuarioModificacion,
                FechaRegistro = DateTime.Now.Date
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
