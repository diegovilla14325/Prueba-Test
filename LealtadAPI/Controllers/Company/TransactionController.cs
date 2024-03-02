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
        
        [HttpPost]
        public async Task<IActionResult> SaveTransaction([FromBody] TransactionDTO transactiondto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("No se pudo realizar la compra");
            }
            var response = _transaccionService.SaveTransaction(transactiondto);
            return Ok(response);
        }
       
    }
}
