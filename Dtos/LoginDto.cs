using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.Dtos;

public class LoginDto
{
    [Required(ErrorMessage = "請輸入帳號")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "請輸入密碼")]
    public string Password { get; set; } = string.Empty;
}