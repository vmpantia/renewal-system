using Microsoft.AspNetCore.Mvc;
using RS.BAL.Models;
using RS.BAL.Services;

namespace RS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _product;
        public ProductController(ProductService product)
        {
            _product = product;   
        }

        [HttpGet]
        public IActionResult GetOne()
        {
            var result = _product.GetAll<ProductDto>();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public IActionResult GetOne(Guid productId)
        {
            var result = _product.GetOne<ProductDto>(data => data.Id == productId);
            return Ok(result);
        }
    }
}
