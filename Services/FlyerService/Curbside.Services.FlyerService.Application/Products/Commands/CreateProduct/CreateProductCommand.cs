using Curbside.Services.Shared.CQRS.Commands;
using System.Linq;
using System.Threading.Tasks;

namespace Curbside.Services.FlyerService.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ICommand
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }

    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly CreateProductCommandValidator _validator;

        public CreateProductCommandHandler(CreateProductCommandValidator validator)
        {
            _validator = validator;
        }

        public async Task<ICommandResult> Handle(CreateProductCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                return new CommandFailedResult(validationResult.Errors.Select(e => e.ToString()));
            }

            return null;
        }
    }
}
