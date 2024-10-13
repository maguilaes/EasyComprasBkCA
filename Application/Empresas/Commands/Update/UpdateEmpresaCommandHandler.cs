using Domain.Entity;
using Domain.Repository;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Empresas.Commands.Update
{
    public class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, int>
    {
        private readonly IEmpresaRepository _entityRepository;
        private readonly IFireBaseService _firebaseService;

        public UpdateEmpresaCommandHandler(IEmpresaRepository entityRepository, IFireBaseService firebaseService)
        {
            _entityRepository = entityRepository;
            _firebaseService = firebaseService;
        }
        public async Task<int> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            #region SUBIR IMAGEN A STORAGE
            string nombreImagen = request.UrlLogo.FileName;
            string nombreImagenExtension = string.Empty;
            //Stream imagenStream = null;

            if (request.UrlLogo != null)
            {
                //string nombre_en_codigo = Guid.NewGuid().ToString("N");
                string extension = Path.GetExtension(request.UrlLogo.FileName);
                string nombreSinExtension = Path.GetFileNameWithoutExtension(request.UrlLogo.FileName);
                nombreImagenExtension = string.Concat(nombreSinExtension, extension);
                //imagenStream = Imagen.OpenReadStream();
            }

            Stream imagen = request.UrlLogo.OpenReadStream();
            var urlImagen = await _firebaseService.SubirStorage(imagen, request.NombreEmpresa, "IMG_EMPRESA", nombreImagenExtension);
            #endregion

            if (urlImagen == null)
            {
                urlImagen = "SinImagen";
            }
            var UpdateEntity = new NegEmpresas()
            {
                Id = request.Id,
                NitEmpresa = request.NitEmpresa,
                NombreEmpresa = request.NombreEmpresa,
                Email = request.Email,
                Leyenda = request.Leyenda,
                UrlLogo = urlImagen.ToString(),
                NombreContacto = request.NombreContacto,
                TelefonoContacto = request.TelefonoContacto,
                IdcCategoria = request.IdcCategoria,
                Ubicacion = request.Ubicacion,
                Estado = request.Estado,
                Coordenadas = request.Coordenadas,
                IdUsuarioModificacion = request.IdUsuarioModificacion,
                FechaModificacion = DateTime.Now.Date
            };

            return await _entityRepository.UpdateAsync(request.Id, UpdateEntity);
        }
    }
}
