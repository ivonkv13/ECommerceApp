using ECommerceApp.Server.Controllers.Products.Dtos;
using ECommerceApp.Server.Services;
using FluentValidation;

namespace ECommerceApp.Server.Controllers.Products.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty()
                .WithMessage("Product Id is required.");

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(dto => dto.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(dto => dto.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock cannot be negative.");
        }
    }
}
