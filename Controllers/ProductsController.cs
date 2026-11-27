using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Interfaces;
using MyFirstApi.Requests;
using Microsoft.AspNetCore.Authorization; // 引入命名空間

namespace MyFirstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IValidator<CreateProductRequest> _createValidator;

    public ProductsController(
        IProductService productService,
        IValidator<CreateProductRequest> createValidator)
    {
        _productService = productService;
        _createValidator = createValidator;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        // 1. 執行 FluentValidation 驗證
        var validationResult = await _createValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => new
            {
                field = e.PropertyName,
                message = e.ErrorMessage
            }));
        }

        // 2. 交由 Service 執行商業邏輯與寫入資料庫
        var created = await _productService.CreateProductAsync(request);
        return Ok(created);
    }
}