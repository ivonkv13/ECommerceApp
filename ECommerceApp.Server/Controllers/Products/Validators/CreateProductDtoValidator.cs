using ECommerceApp.Server.Controllers.Products.Dtos;
using FluentValidation;

namespace ECommerceApp.Server.Controllers.Products.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(dto => dto.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(dto => dto.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(dto => dto.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");
        }
    }
}
