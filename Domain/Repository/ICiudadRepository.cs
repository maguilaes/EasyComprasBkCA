using Domain.Entity;

namespace Domain.Repository
{
    public interface ICiudadRepository
    {
        Task<List<BaseCiudades>> GetAllAsync();
        Task<BaseCiudades> GetByIdAsync(int id);
        Task<BaseCiudades> CreateAsync(BaseCiudades data);
        Task<int> UpdateAsync(int id, BaseCiudades data);
        Task<int> DeleteAsync(int id);
    }
}
