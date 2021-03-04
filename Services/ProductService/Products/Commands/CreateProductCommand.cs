using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductService.Models;

namespace ProductService.Products.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        public CreateProductCommandHandler()
        {

        }

        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Guid systemId = Guid.NewGuid();

            var product = new Product
            {
                Price = command.Price,
                Name = command.Name,
                ExternalId = command.ExternalId,
                SystemId = systemId,
            };

            return systemId;
        }
    }
}
