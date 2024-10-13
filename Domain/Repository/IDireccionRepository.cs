using Domain.Entity;

namespace Domain.Repository;

public interface IDireccionRepository
{
    Task<List<BaseDirecciones>> GetAllAsync();
    Task<BaseDirecciones> GetByIdAsync(int id);
    Task<BaseDirecciones> GetByRelacionIdAsync(string idrelacion);
    Task<List<BaseDirecciones>> GetAllByPaisCiudadIdAsync(int idpais, int idciudad);
    Task<BaseDirecciones> CreateAsync(BaseDirecciones data);
    Task<int> UpdateAsync(int id, BaseDirecciones data);
    Task<int> DeleteAsync(int id);
}
