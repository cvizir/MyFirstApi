using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
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

    // 1. 取得所有商品 (GET: api/products)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    // 2. 取得單筆商品 (GET: api/products/1)
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

    // 3. 新增商品 (POST: api/products)
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        // 回傳 HTTP 201 Created，並在 Header 附上單筆查詢的網址
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // 4. 修改商品 (PUT: api/products/1)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
    {
        var existingProduct = await _context.Products.FindAsync(id);

        if (existingProduct == null)
        {
            return NotFound(new { message = $"找不到 ID 為 {id} 的商品" });
        }

        // 更新欄位資料
        existingProduct.Name = updatedProduct.Name;
        existingProduct.Price = updatedProduct.Price;

        await _context.SaveChangesAsync();

        // 更新成功通常回傳 HTTP 204 No Content
        return NoContent();
    }

    // 5. 刪除商品 (DELETE: api/products/1)
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