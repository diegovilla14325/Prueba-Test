using Domain.Entities.Company.DTOs;
using Domain.Entities.Company;
using Repository.Repositories.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.IService.Company;

namespace Service.Service.Company
{
    public class RewardService : IRewardService
    {
        private readonly RewardRepository _rewardRepository;
        public RewardService(RewardRepository rewardRepository)
        {
            _rewardRepository = rewardRepository;
        }
        public async Task CreateReward(RewardDTO rewarddto)
        {

            try
            {
                var reward = new Reward();
                reward.nombrePremio = rewarddto.nombrePremio;
                reward.ValorEnPuntos = rewarddto.ValorEnPuntos;

                if (await _rewardRepository.CreateReward(reward) > 0)
                {
                    Console.WriteLine("Se agrego el Premio");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task RedeemPrize(RewardLogDTO rewardlogdto)
        {

            try
            {
                var rewardlog = new RewardLog();
                rewardlog.idPremio = rewardlogdto.idPremio;
                rewardlog.idUsuario = rewardlogdto.idUsuario;
                rewardlog.fechaCanje= rewardlogdto.fechaCanje;

                if (await _rewardRepository.RedeemPrize(rewardlog) > 0)
                {
                    Console.WriteLine("Se agrego el Premio");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task<List<RewardDTO>> GetRewards()
        {
            var rewards = new List<RewardDTO>();

            try
            {
                rewards = await _rewardRepository.GetRewards();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return rewards;
        }
    }
}
