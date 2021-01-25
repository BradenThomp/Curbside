using CQRS.Commands;
using System;
using System.Threading.Tasks;

namespace Curbside.Services.FlyerService.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ICommand
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }

    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
    {

        public CreateProductCommandHandler()
        {

        }

        public async Task<Guid> Handle(CreateProductCommand command)
        {
            return new Guid();
        }
    }
}
