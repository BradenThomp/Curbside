using FluentValidation;

namespace Curbside.Services.FlyerService.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(v => v.Price).NotEmpty();
            RuleFor(v => v.Name).NotEmpty();
        }
    }
}
