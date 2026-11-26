using MyFirstApi.Dtos; // 一定要在最上面，不然會報錯
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
    // GET: api/products?keyword=滑鼠&page=1&pageSize=10
    [HttpGet]
    public async Task<ActionResult<PagedResult<Product>>> GetAll(
    [FromQuery] string? keyword,
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 20)
    {
        // 1. 參數防呆：避免前端傳入負數或一次撈取過多資料
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 20;
        if (pageSize > 100) pageSize = 100;

        // 2. 建立基礎查詢（AsNoTracking 可提升純讀取效能）
        var query = _context.Products.AsNoTracking().AsQueryable();

        // 3. 關鍵字搜尋（有傳入 keyword 時才加上 WHERE 條件）
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            keyword = keyword.Trim();
            // 對應 MySQL 的 LIKE '%keyword%'，請將 p.Name 換成你實際的欄位名稱
            query = query.Where(p => p.Name != null && p.Name.Contains(keyword));
        }

        // 4. 先計算符合搜尋條件的總筆數
        var totalCount = await query.CountAsync();

        // 5. 排序並進行分頁（請將 p.ProductId 換成你實際的主鍵欄位）
        var items = await query
            .OrderBy(p => p.Uptime)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        // 6. 封裝成統一的分頁格式回傳
        var result = new PagedResult<Product>
        {
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
            Items = items
        };

        return Ok(result);
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

    // 測試用：故意拋出未預期的錯誤（測試完可刪除）
    [HttpGet("test-error")]
    public IActionResult TestError()
    {
        throw new Exception("這是故意觸發的測試錯誤！");
    }


}