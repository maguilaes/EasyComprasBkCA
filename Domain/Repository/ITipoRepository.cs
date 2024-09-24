using Domain.Entity;

namespace Domain.Repository
{
    public interface ITipoRepository
    {
        Task<List<BaseTipos>> GetAllAsync();
        Task<BaseTipos> GetByIdAsync(int id);
        Task<BaseTipos> CreateAsync(BaseTipos data);
        Task<int> UpdateAsync(int id, BaseTipos data);
        Task<int> DeleteAsync(int id);
    }
}
