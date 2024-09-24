using Application.Interface;
using Firebase.Auth;
using Firebase.Storage;

namespace Application.Service
{
    public class FireBaseService : IFireBaseService
    {
        private readonly IGenericRepository<INIConfiguracion> _repositorio;
        private readonly ContextConfig _context;
        //private readonly EnvFirebaseConfig _varFirebase;
        public FireBaseService(ContextConfig context, IGenericRepository<INIConfiguracion> repositorio)
        {
            _context = context;
            //_varFirebase = varFirebase.Value;
            _repositorio = repositorio;
        }

        public async Task<bool> EliminarStorage(string Repositorio, string NombreEmpresa, string NombreArchivo)
        {
            try
            {
                IQueryable<INIConfiguracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));
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

        public async Task<string> SubirStorage(Stream StreamArchivo, string NombreEmpresa, string CarpetaDestino, string NombreArchivo)
        {
            string UrlImagen = string.Empty;

            try
            {
                IQueryable<INIConfiguracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));
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
                //IQueryable<INIConfiguracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));
                //Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);
            }
            catch
            {
                UrlImagen = $"Error al subir la imagen: {NombreArchivo}";
            }
            return UrlImagen;
        }
    }
}
