using Domain.Entity;

namespace Domain.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<SegUsuarios>> GetAllAsync();
        Task<SegUsuarios> GetByIdAsync(int id);
        Task<SegUsuarios> CreateAsync(SegUsuarios data);
        Task<int> UpdateAsync(int id, SegUsuarios data);
        Task<int> DeleteAsync(int id);
    }
}
