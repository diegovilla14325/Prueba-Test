using Domain.Entities.Company.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.IService.Company;
using Service.Service.Company;

namespace LealtadAPI.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productService.GetProducts();
            if (!response.Any())
            {
                return BadRequest("No se encontraron productos");
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetProductId")]
        public async Task<IActionResult> GetProductByIds(int idProducto)
        {
            var response = await _productService.GetProductByIds(idProducto);
            if (!response.Any())
            {
                return BadRequest("No se encontraron productos");
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ingrese bien los datos");
            }
            var response = _productService.CreateProduct(productdto);
            return Ok(response);
        }
    }
}
