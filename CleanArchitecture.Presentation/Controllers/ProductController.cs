using CleanArchitecture.Application.Commands_Queries.Queries.GetsProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender sender) : ControllerBase
    {
        [HttpGet("gets-product")]
        public async Task<IActionResult> GetsProduct()
        {
            var products = await sender.Send(new GetsProductQuery());
            return Ok(products);
        }
    }
}
