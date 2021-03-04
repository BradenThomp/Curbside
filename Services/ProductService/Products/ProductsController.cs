using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using ProductService.Products.Commands;

namespace ProductService.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return new JsonResult(result);
        }
    }
}
