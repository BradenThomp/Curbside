using Curbside.Services.FlyerService.Application.Products.Commands.CreateProduct;
using Curbside.Services.Shared.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Curbside.Services.FlyerService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ProductController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<ICommandResult> CreateProduct(CreateProductCommand command)
        {
            return await _commandDispatcher.Execute(command);
        }
    }
}
