using FluentValidation;
using MyFirstApi.Requests;

namespace MyFirstApi.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("商品名稱為必填欄位")
            .MaximumLength(100).WithMessage("商品名稱不可超過 100 個字元");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("商品價格必須大於或等於 0");
    }
}