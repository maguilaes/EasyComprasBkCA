namespace Domain.Repository
{
    public interface IHashService
    {
        string GenerarClave();

        string ConvertirSha256(string texto);
    }
}
