using Domain.Entities.Company.DTOs;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;
using Service.IService.Company;
using Service.Service.Company;

namespace LealtadAPI.Controllers.Company
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardController : Controller
    {
        private readonly IRewardService _rewardService;

        public RewardController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }

        [HttpPost]
        [Route("CreateReward")]
        public async Task<IActionResult> CreateReward([FromBody] RewardDTO rewarddto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ingrese bien los datos del premio");
            }
            var response = _rewardService.CreateReward(rewarddto);
            return Ok(response);
        }

        [HttpPost]
        [Route("RedeemPrize")]
        public async Task<IActionResult> RedeemPrize([FromBody] RewardLogDTO rewardlogdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("No tiene los puntos suficientes");
            }
            var response = _rewardService.RedeemPrize(rewardlogdto);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetRewards")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRewards()
        {
            var response = await _rewardService.GetRewards();
            if (!response.Any())
            {
                return BadRequest("No se encontraron productos");
            }
            return Ok(response);
        }
    }

}
