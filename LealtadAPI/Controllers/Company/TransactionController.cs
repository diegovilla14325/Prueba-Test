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
    }
}
