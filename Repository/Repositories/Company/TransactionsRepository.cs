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
    public class TransactionsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var products = await _dbContext.ProductDTOs.FromSqlRaw("Call ObtenerProductos()").ToListAsync();
            return products;
        }
    }
}
