using Curbside.Services.FlyerService.Application.Common.Models;
using Curbside.Services.FlyerService.Application.Products.Commands.CreateProduct;
using Curbside.Services.Shared.CQRS.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

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
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _commandDispatcher.Execute<CreateProductCommand, Guid>(command);

            return new JsonResult(result);
        }
    }
}
