using MyFirstApi.Models;

namespace MyFirstApi.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<bool> ExistsByNameAsync(string name);
    Task<Product> AddAsync(Product product);
}