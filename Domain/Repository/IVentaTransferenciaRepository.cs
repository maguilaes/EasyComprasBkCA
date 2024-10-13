using Domain.Entity;

namespace Domain.Repository
{
    public interface IVentaTransferenciaRepository
    {
        Task<List<TrxVentasTransferencia>> GetAllAsync();
        Task<TrxVentasTransferencia> GetByIdAsync(int id);
        Task<TrxVentasTransferencia> CreateAsync(TrxVentasTransferencia data);
        Task<int> UpdateAsync(int id, TrxVentasTransferencia data);
        Task<int> DeleteAsync(int id);
    }
}
