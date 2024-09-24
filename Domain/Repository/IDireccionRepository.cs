using Domain.Entity;

namespace Domain.BASDireccion;

public interface IDireccionRepository
{
    Task<List<BaseDirecciones>> GetAllAsync();
    Task<BaseDirecciones> GetByIdAsync(int id);
    Task<BaseDirecciones> CreateAsync(BaseDirecciones data);
    Task<int> UpdateAsync(int id, BaseDirecciones data);
    Task<int> DeleteAsync(int id);
}
