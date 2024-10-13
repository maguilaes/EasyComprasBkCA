namespace Domain.Repository
{
    public interface IFireBaseService
    {
        Task<string> SubirStorage(Stream StreamArchivo, string NombreEmpresa, string CarpetaDestino, string NombreArchivo);
        Task<bool> EliminarStorage(string Repositorio, string NombreEmpresa, string NombreArchivo);
    }
}
