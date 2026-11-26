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

    // 1. 取得所有資料 (GET: api/users)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    // 2. 取得單筆資料 (GET: api/users/1)
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var item = await _context.Products.FindAsync(id);

        if (item == null)
        {
            return NotFound(new { message = $"找不到 ID 為 {id} 的資料" });
        }

        return item;
    }

    // 3. 新增資料 (POST: api/users)
    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product newItem)
    {
        _context.Products.Add(newItem);
        await _context.SaveChangesAsync();

        // 若你的主鍵欄位不叫 Id（例如 ProductId），請將下方的 newItem.Id 改為對應屬性
        return CreatedAtAction(nameof(GetById), new { id = newItem.ProductCode }, newItem);
    }

    // 4. 修改資料 (PUT: api/users/1)
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(String id, Product updatedItem)
    {
        if (id != updatedItem.ProductCode)
        {
            return BadRequest(new { message = "網址的 ID 與資料內容不一致" });
        }

        _context.Entry(updatedItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var exists = await _context.Products.FindAsync(id);
            if (exists == null)
            {
                return NotFound(new { message = $"找不到 ID 為 {id} 的資料" });
            }
            throw;
        }

        return NoContent();
    }

    // 5. 刪除資料 (DELETE: api/users/1)
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Products.FindAsync(id);
        if (item == null)
        {
            return NotFound(new { message = $"找不到 ID 為 {id} 的資料" });
        }

        _context.Products.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}