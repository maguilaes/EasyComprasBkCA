using Domain.Entity;

namespace Domain.Repository
{
    public interface IClasificadorRepository
    {
        Task<List<BaseClasificadores>> GetAllAsync();
        Task<BaseClasificadores> GetByIdAsync(int id);
        Task<BaseClasificadores> CreateAsync(BaseClasificadores data);
        Task<int> UpdateAsync(int id, BaseClasificadores data);
        Task<int> DeleteAsync(int id);
    }
}
