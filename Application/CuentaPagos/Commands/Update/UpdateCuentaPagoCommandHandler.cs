using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.CuentaPagos.Commands.Update
{
    public class UpdateCuentaPagoCommandHandler : IRequestHandler<UpdateCuentaPagoCommand, int>
    {
        private readonly ICuentaPagoRepository _entityRepository;
        private readonly IFireBaseService _firebaseService;

        public UpdateCuentaPagoCommandHandler(ICuentaPagoRepository entityRepository, IFireBaseService firebaseService)
        {
            _entityRepository = entityRepository;
            _firebaseService = firebaseService;
        }
        public async Task<int> Handle(UpdateCuentaPagoCommand request, CancellationToken cancellationToken)
        {
            #region SUBIR IMAGEN A STORAGE
            string nombreImagen = request.UrlQr.FileName;
            string nombreImagenExtension = string.Empty;
            //Stream imagenStream = null;

            if (request.UrlQr != null)
            {
                //string nombre_en_codigo = Guid.NewGuid().ToString("N");
                string extension = Path.GetExtension(request.UrlQr.FileName);
                string nombreSinExtension = Path.GetFileNameWithoutExtension(request.UrlQr.FileName);
                nombreImagenExtension = string.Concat(nombreSinExtension, extension);
                //imagenStream = Imagen.OpenReadStream();
            }

            Stream imagen = request.UrlQr.OpenReadStream();
            var urlImagen = await _firebaseService.SubirStorage(imagen, request.NombreEmpresa, "IMG_EMPRESA", nombreImagenExtension);
            #endregion

            if (urlImagen == null)
            {
                urlImagen = "SinImagen";
            }

            var UpdateEntity = new NegCuentaPagos()
            {
                Id = request.Id,
                NroCuentaPagos = request.NroCuentaPagos,
                BancoPagos = request.BancoPagos,
                NombreTitular = request.NombreTitular,
                DocumentoTitular = request.DocumentoTitular,
                UrlQr = urlImagen.ToString(),
                IdSucursal = request.IdSucursal,
                IdUsuarioModificacion = request.IdUsuarioModificacion,
                FechaModificacion = DateTime.Now.Date,
                Estado = request.Estado
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
