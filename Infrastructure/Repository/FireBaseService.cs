using AutoMapper;
using Domain.Repository;
using Firebase.Auth;
using Firebase.Storage;

namespace Infrastructure.Repository
{
    public class FireBaseService : IFireBaseService
    {
        private readonly IConfigRepository _entityRepository;
        private readonly IMapper _mapper;
        public FireBaseService(IConfigRepository configRepository, IMapper mapper)
        {
            _entityRepository = configRepository;
            _mapper = mapper;
        }
        public async Task<string> SubirStorage(Stream StreamArchivo, string NombreEmpresa, string CarpetaDestino, string NombreArchivo)
        {
            string UrlImagen = string.Empty;

            try
            {
                var query = await _entityRepository.GetByRecursoAsync("FireBase_Storage");
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api_key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(Config["email"], Config["clave"]);

                var cancellation = new CancellationTokenSource();
                var task = new FirebaseStorage(
                    Config["ruta"],
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    .Child(NombreEmpresa)
                    .Child(CarpetaDestino)
                    .Child(NombreArchivo)
                    .PutAsync(StreamArchivo, cancellation.Token);

                UrlImagen = await task;
            }
            catch
            {
                UrlImagen = $"Error al subir la imagen: {NombreArchivo}";
            }
            return UrlImagen;
        }

        public async Task<string> ObtenerUrlStorage(string CarpetaOrigen, string NombreEmpresa, string NombreArchivo)
        {
            string UrlImagen = string.Empty;
            try
            {
                var query = await _entityRepository.GetByRecursoAsync("FireBase_Storage");
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);
            }
            catch
            {
                UrlImagen = $"Error al subir la imagen: {NombreArchivo}";
            }
            return UrlImagen;
        }

        public async Task<bool> EliminarStorage(string Repositorio, string NombreEmpresa, string NombreArchivo)
        {
            try
            {
                var query = await _entityRepository.GetByRecursoAsync("FireBase_Storage");
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api_key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(Config["email"], Config["clave"]);

                var cancellation = new CancellationTokenSource();
                var task = new FirebaseStorage(
                    Config["ruta"],
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    .Child(Repositorio)
                    .Child(NombreEmpresa)
                    .Child(NombreArchivo)
                    .DeleteAsync();

                await task;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
