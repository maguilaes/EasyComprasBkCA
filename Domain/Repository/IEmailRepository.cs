using Domain.Entity;

namespace Domain.Repository
{
    public interface IEmailRepository
    {
        Task<List<IniEmail>> GetAllAsync();
        Task<IniEmail> GetByIdAsync(int id);
        Task<IniEmail> CreateAsync(IniEmail data);
        Task<int> UpdateAsync(int id, IniEmail data);
        Task<int> DeleteAsync(int id);
    }
}
