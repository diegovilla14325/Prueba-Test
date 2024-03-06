using Domain.Entities.Company;
using Domain.Entities.Company.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Company
{
    public class RewardRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RewardRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateReward(Reward reward)
        {
            _dbContext.Rewards.Add(reward);
            return _dbContext.SaveChanges();

        }
        public async Task<int> RedeemPrize(RewardLog rewardlog)
        {
            _dbContext.RewardsLog.Add(rewardlog);
            return _dbContext.SaveChanges();

        }
        public async Task<List<RewardDTO>> GetRewards()
        {
            var rewards = await _dbContext.RewardDTOs.FromSqlRaw("Call ObtenerPremios()").ToListAsync();
            return rewards;
        }
    }
}
