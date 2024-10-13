using Application.CuentaPagos.Queries.GetCuentaPagos;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.CuentaPagos.Commands.Create;

public sealed class CreateCuentaPagoCommandHandler : IRequestHandler<CreateCuentaPagoCommand, CuentaPagosVM>
{
    private readonly ICuentaPagoRepository _entityRepository;
    private readonly IFireBaseService _firebaseService;
    private readonly IMapper _mapper;

    public CreateCuentaPagoCommandHandler(ICuentaPagoRepository entityRepository, IMapper mapper, IFireBaseService firebaseService)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
        _firebaseService = firebaseService;
    }

    public async Task<CuentaPagosVM> Handle(CreateCuentaPagoCommand command, CancellationToken cancellationToken)
    {
        #region SUBIR IMAGEN A STORAGE
        string nombreImagen = command.UrlQr.FileName;
        string nombreImagenExtension = string.Empty;
        //Stream imagenStream = null;

        if (command.UrlQr != null)
        {
            //string nombre_en_codigo = Guid.NewGuid().ToString("N");
            string extension = Path.GetExtension(command.UrlQr.FileName);
            string nombreSinExtension = Path.GetFileNameWithoutExtension(command.UrlQr.FileName);
            nombreImagenExtension = string.Concat(nombreSinExtension, extension);
            //imagenStream = Imagen.OpenReadStream();
        }

        Stream imagen = command.UrlQr.OpenReadStream();
        var urlImagen = await _firebaseService.SubirStorage(imagen, command.NombreEmpresa, "IMG_EMPRESA", nombreImagenExtension);
        #endregion

        if (urlImagen == null)
        {
            urlImagen = "SinImagen";
        }

        var data = new NegCuentaPagos
        {
            NroCuentaPagos = command.NroCuentaPagos,
            BancoPagos = command.BancoPagos,
            NombreTitular = command.NombreTitular,
            DocumentoTitular = command.DocumentoTitular,
            UrlQr = urlImagen.ToString(),
            IdUsuarioRegistro = command.IdUsuarioRegistro,
            FechaRegistro = DateTime.Now.Date,
            IdSucursal = command.IdSucursal,
            Estado = true
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<CuentaPagosVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.NroCuentaPagos}");
    }
}
