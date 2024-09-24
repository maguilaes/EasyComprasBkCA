namespace Application.Interface
{
    public interface IHashService
    {
        string GenerarClave();

        string ConvertirSha256(string texto);
    }
}
