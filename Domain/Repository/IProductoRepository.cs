using Domain.Entity;

namespace Domain.Repository
{
    public interface IProductoRepository
    {
        Task<List<NegProductos>> GetAllAsync();
        Task<NegProductos> GetByIdAsync(int id);
        Task<NegProductos> CreateAsync(NegProductos data);
        Task<int> UpdateAsync(int id, NegProductos data);
        Task<int> DeleteAsync(int id);
    }
}
