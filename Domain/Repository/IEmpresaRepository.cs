using Domain.Entity;

namespace Domain.Repository
{
    public interface IEmpresaRepository
    {
        Task<List<NegEmpresas>> GetAllAsync();
        Task<NegEmpresas> GetByIdAsync(int id);
        Task<NegEmpresas> CreateAsync(NegEmpresas data);
        Task<int> UpdateAsync(int id, NegEmpresas data);
        Task<int> DeleteAsync(int id);
    }
}
