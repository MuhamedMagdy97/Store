using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Services.interfaces;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet] //baseurl \api\Products
        public async Task <IActionResult> GetAllProducts()
        { 
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpGet ("brands")]

        public async Task<IActionResult> GetAllBrands()
        {
            var result = await _productService.GetAllBrandsAsync();
            return Ok(result);
        }

        [HttpGet("types")]

        public async Task<IActionResult> GetAllTypes()
        {
            var result = await _productService.GetAllTypesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductById(int? id)
        {
            if(id is null) return BadRequest("Invalid id !!"); 
            var result = await _productService.GetProductById(id.Value);

            if(result is null) return NotFound();

            return Ok(result);
        }
    }
}
