using Domain.Entities.Company;
using Domain.Entities.Company.DTOs;
using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Reward> Rewards { get; set; }

        public virtual DbSet<RewardLog> RewardsLog { get; set; }

        public virtual DbSet<Transaction> Transactions { get; set; }

        public virtual DbSet<TransactionLog> TransactionsLog { get; set; }

        public virtual DbSet<Point> Points { get; set; }

        public virtual DbSet<User> Users { get; set; }

        //Data Transfer Objects
        public virtual DbSet<ProductDTO> ProductDTOs { get; set; }

        public virtual DbSet<UserDTO> UserDTOs { get; set;}

        public virtual DbSet<LoginDTO> LoginDTOs { get; set; }

        public virtual DbSet<RewardDTO> RewardDTOs { get; set;}

        public virtual DbSet<UserPointsDTO> UserPointsDTOs { get; set; }

        public virtual DbSet<RewardLogDTO> RewardLogDTOs { get;set; }
        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        //{
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}
    }

}
