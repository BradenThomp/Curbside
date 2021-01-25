using Curbside.Services.FlyerService.Application.Products.Commands.CreateProduct;
using CQRS.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Curbside.Services.FlyerService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly IDispatcher _dispatcher;

        public ProductController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _dispatcher.Execute<CreateProductCommand, Guid>(command);

            return new JsonResult(result);
        }
    }
}
