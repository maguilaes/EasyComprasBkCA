using Domain.Entity;

namespace Domain.Repository
{
    public interface IConfigRepository
    {
        Task<List<IniConfig>> GetAllAsync();
        Task<IniConfig> GetByIdAsync(int id);
        Task<IniConfig> CreateAsync(IniConfig data);
        Task<int> UpdateAsync(int id, IniConfig data);
        Task<int> DeleteAsync(int id);
    }
}
