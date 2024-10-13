using Application.Empresas.Queries.GetEmpresas;
using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using MediatR;

namespace Application.Empresas.Commands.Create;

public class CreateEmpresaCommandHandler : IRequestHandler<CreateEmpresaCommand, EmpresasVM>
{
    private readonly IEmpresaRepository _entityRepository;
    private readonly IFireBaseService _firebaseService;
    private readonly IMapper _mapper;

    public CreateEmpresaCommandHandler(IEmpresaRepository entityRepository, IMapper mapper, IFireBaseService firebaseService)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
        _firebaseService = firebaseService;
    }

    public async Task<EmpresasVM> Handle(CreateEmpresaCommand command, CancellationToken cancellationToken)
    {
        #region SUBIR IMAGEN A STORAGE
        string nombreImagen = command.UrlLogo.FileName;
        string nombreImagenExtension = string.Empty;
        //Stream imagenStream = null;

        if (command.UrlLogo != null)
        {
            //string nombre_en_codigo = Guid.NewGuid().ToString("N");
            string extension = Path.GetExtension(command.UrlLogo.FileName);
            string nombreSinExtension = Path.GetFileNameWithoutExtension(command.UrlLogo.FileName);
            nombreImagenExtension = string.Concat(nombreSinExtension, extension);
            //imagenStream = Imagen.OpenReadStream();
        }

        Stream imagen = command.UrlLogo.OpenReadStream();
        var urlImagen = await _firebaseService.SubirStorage(imagen, command.NombreEmpresa, "IMG_EMPRESA", nombreImagenExtension);
        #endregion

        if (urlImagen == null)
        {
            urlImagen = "SinImagen";
        }
        var data = new NegEmpresas
        {
            NitEmpresa = command.NitEmpresa,
            NombreEmpresa = command.NombreEmpresa,
            Email = command.Email,
            Leyenda = command.Leyenda,
            UrlLogo = urlImagen.ToString(),
            NombreContacto = command.NombreContacto,
            TelefonoContacto = command.TelefonoContacto,
            IdcCategoria = command.IdcCategoria,
            Ubicacion = command.Ubicacion,
            Estado = command.Estado,
            Coordenadas = command.Coordenadas,
            IdUsuarioRegistro = command.IdUsuarioRegistro,
            FechaRegistro = DateTime.Now.Date
        };

        var valor = await _entityRepository.CreateAsync(data);
        if (valor != null)
        {
            return _mapper.Map<EmpresasVM>(data);
        }
        throw new KeyNotFoundException($"Error al insertar {command.NombreEmpresa}");
    }
}

