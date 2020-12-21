using Curbside.Services.Shared.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curbside.Services.FlyerService.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ICommand
    {

    }

    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        public Task Handle(CreateProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
