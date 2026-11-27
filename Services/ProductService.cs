using MyFirstApi.Interfaces;
using MyFirstApi.Models;
using MyFirstApi.Requests;

namespace MyFirstApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Product> CreateProductAsync(CreateProductRequest request)
    {
        // 商業邏輯範例：檢查商品名稱是否重複
        if (await _repository.ExistsByNameAsync(request.Name))
        {
            throw new InvalidOperationException($"商品名稱「{request.Name}」已存在");
        }

        var product = new Product
        {
            Name = request.Name,
        };

        return await _repository.AddAsync(product);
    }
}