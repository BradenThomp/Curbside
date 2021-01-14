using Curbside.Services.Shared.CQRS.Commands;
using FluentValidation;
using System;
using System.Threading.Tasks;
using ValidationException = Curbside.Services.FlyerService.Application.Common.Exceptions.ValidationException;

namespace Curbside.Services.FlyerService.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ICommand
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }

    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {

        private readonly AbstractValidator<CreateProductCommand> _validator;

        public CreateProductCommandHandler(CreateProductCommandValidator validator)
        {
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateProductCommand command)
        {
            var validation = await _validator.ValidateAsync(command);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            return new Guid();
        }
    }
}
