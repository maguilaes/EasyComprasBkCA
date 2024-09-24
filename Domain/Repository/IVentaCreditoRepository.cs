using Domain.Entity;

namespace Domain.Repository
{
    public interface IVentaCreditoRepository
    {
        Task<List<TrxVentasCredito>> GetAllAsync();
        Task<TrxVentasCredito> GetByIdAsync(int id);
        Task<TrxVentasCredito> CreateAsync(TrxVentasCredito data);
        Task<int> UpdateAsync(int id, TrxVentasCredito data);
        Task<int> DeleteAsync(int id);
    }
}
