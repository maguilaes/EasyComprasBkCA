using Domain.Entity;

namespace Domain.Repository
{
    public interface IVentaRepository
    {
        Task<List<TrxVentas>> GetAllAsync();
        Task<TrxVentas> GetByIdAsync(int id);
        Task<TrxVentas> CreateAsync(TrxVentas data);
        Task<int> UpdateAsync(int id, TrxVentas data);
        Task<int> DeleteAsync(int id);
    }
}
