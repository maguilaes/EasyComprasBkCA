using Domain.Entity;

namespace Domain.Repository
{
    public interface ICuentaPagoRepository
    {
        Task<List<NegCuentaPagos>> GetAllAsync();
        Task<NegCuentaPagos> GetByIdAsync(int id);
        Task<List<NegCuentaPagos>> GetByPaisIdAsync(int idpais);
        Task<NegCuentaPagos> CreateAsync(NegCuentaPagos data);
        Task<int> UpdateAsync(int id, NegCuentaPagos data);
        Task<int> DeleteAsync(int id);
    }
}
