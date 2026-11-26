using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.Dtos;

// 新增商品用的 DTO（不包含 Id，由資料庫自動產生）
public class CreateProductDto
{
    [Required(ErrorMessage = "商品名稱為必填欄位")]
    [StringLength(100, ErrorMessage = "商品名稱不可超過 100 個字元")]
    public string Name { get; set; } = string.Empty;

    [Range(0, 99999999, ErrorMessage = "商品價格必須大於或等於 0")]
    public decimal Price { get; set; }
}

// 修改商品用的 DTO
public class UpdateProductDto
{
    [Required(ErrorMessage = "商品名稱為必填欄位")]
    [StringLength(100, ErrorMessage = "商品名稱不可超過 100 個字元")]
    public string Name { get; set; } = string.Empty;

    [Range(0, 99999999, ErrorMessage = "商品價格必須大於或等於 0")]
    public decimal Price { get; set; }
}