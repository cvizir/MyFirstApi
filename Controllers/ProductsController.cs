using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using MyFirstApi.Dtos;   // 引入 DTO 命名空間
using MyFirstApi.Models;

namespace MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // 1. 取得所有商品
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    // 2. 取得單筆商品
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound(new { message = $"找不到 ID 為 {id} 的商品" });
        }
        return product;
    }

    // 3. 新增商品（改用 CreateProductDto）
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(CreateProductDto dto)
    {
        // 將 DTO 轉換成資料庫實體 (Entity)
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // 4. 修改商品（改用 UpdateProductDto）
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto dto)
    {
        var existingProduct = await _context.Products.FindAsync(id);
        if (existingProduct == null)
        {
            return NotFound(new { message = $"找不到 ID 為 {id} 的商品" });
        }

        existingProduct.Name = dto.Name;
        existingProduct.Price = dto.Price;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // 5. 刪除商品
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound(new { message = $"找不到 ID 為 {id} 的商品" });
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}