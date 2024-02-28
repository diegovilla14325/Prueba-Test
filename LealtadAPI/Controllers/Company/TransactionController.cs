using Domain.Entities.Company.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.IService.Company;

namespace LealtadAPI.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransaccionService _transaccionService;

        public TransactionController( ITransaccionService transactionService)
        {
            _transaccionService = transactionService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts()
        {
            var response= await _transaccionService.GetProducts();
            if(!response.Any())
            {
                return BadRequest("No se encontraron productos");
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetProductId")]
        public async Task<IActionResult> GetProductByIds(int idProducto)
        {
            var response = await _transaccionService.GetProductByIds(idProducto);
            if (!response.Any())
            {
                return BadRequest("No se encontraron productos");
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody]ProductDTO productdto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Escribe bien los datos");
            }
            var response =   _transaccionService.CreateProduct(productdto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> SaveTransaction([FromBody] TransactionDTO transactiondto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Mmste");
            }
            var response = _transaccionService.SaveTransaction(transactiondto);
            return Ok(response);
        }
    }
}
