using Domain.Entity;

namespace Domain.Repository
{
    public interface ISucursalRepository
    {
        Task<List<NegSucursales>> GetAllAsync();
        Task<NegSucursales> GetByIdAsync(int id);
        Task<NegSucursales> CreateAsync(NegSucursales data);
        Task<int> UpdateAsync(int id, NegSucursales data);
        Task<int> DeleteAsync(int id);
    }
}
