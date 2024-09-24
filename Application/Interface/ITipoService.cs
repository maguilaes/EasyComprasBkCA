using Domain.Entity;

namespace Application.Interface
{
    public interface ITipoService
    {
        List<BaseTipos> GetAllTipos();

        BaseTipos Create(BaseTipos tipos);
    }
}
