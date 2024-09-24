using Domain.Entity;

namespace Domain.Repository
{
    public interface IDetVentaRepository
    {
        Task<List<TrxDetalleVentas>> GetAllAsync();
        Task<TrxDetalleVentas> GetByIdAsync(int id);
        Task<TrxDetalleVentas> CreateAsync(TrxDetalleVentas data);
        Task<int> UpdateAsync(int id, TrxDetalleVentas data);
        Task<int> DeleteAsync(int id);
    }
}
