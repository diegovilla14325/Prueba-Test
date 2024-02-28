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
        public async Task<List<ProductDTO>> GetProductById(int idProducto)
        { 
            var productId = await _dbContext.ProductDTOs.FromSqlRaw($"Call ObtenerProductosById({idProducto})").ToListAsync();
            return productId;
        }
        public async Task<int> CreatedProduct(Product product)
        {
            _dbContext.Products.Add(product);
            return  _dbContext.SaveChanges();
            
        }
        public async Task<int> SaveTransaction(Transaction transaction)
        {
             _dbContext.Transactions.Add(transaction);
            return  _dbContext.SaveChanges();

        }
    }
}
