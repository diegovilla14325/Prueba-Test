using Domain.Entities.Company;
using Domain.Entities.Company.DTOs;
using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual DbSet<ProductDTO> ProductDTOs { get; set; }
    }
}
