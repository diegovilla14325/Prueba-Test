using Domain.Entities.Company.DTOs;
using Repository.Repositories.Company;
using Service.IService.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Company
{
    public class TransaccionService : ITransaccionService
    {
        private readonly TransactionsRepository _transactionsRepository;

        public TransaccionService(TransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        public async Task<List<ProductDTO>> GetProducts() { 
            var Products= new List<ProductDTO>();

            try
            {
                Products = await _transactionsRepository.GetProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Products;
        }
    }
}
