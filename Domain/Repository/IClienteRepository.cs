using Domain.Entity;

namespace Domain.Repository;

public interface IClienteRepository
{
    Task<List<NegClientes>> GetAllAsync();
    Task<NegClientes> GetByIdAsync(int id);
    Task<NegClientes> CreateAsync(NegClientes data);
    Task<int> UpdateAsync(int id, NegClientes data);
    Task<int> DeleteAsync(int id);
}

