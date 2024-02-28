using Domain.Entities.Company;
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
        public async Task<List<ProductDTO>> GetProductByIds(int idProducto)
        {
            var Products = new List<ProductDTO>();
            try
            {
                Products = await _transactionsRepository.GetProductById(idProducto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Products;
        }
        public async Task CreateProduct(ProductDTO productdto)
        {
            
            try
            {
                var product = new Product();
                product.nombreProducto = productdto.nombreProducto;
                product.precio = productdto.precio;

                if (await _transactionsRepository.CreatedProduct(product) > 0)
                {
                    Console.WriteLine("imon");
                }
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task SaveTransaction(TransactionDTO transactiondto)
        {
            

            try
            {
                var transaction = new Transaction()
                {
                    idUsuario = transactiondto.idUsuario,
                    fechaCompra = transactiondto.fechaCompra,
                    TotalCompra = transactiondto.totalCompra,
                };
                foreach (var item in transactiondto.transactionLogs)
                {
                    transaction.transactionLogs.Add(new TransactionLog()
                    {
                        idProducto = item.idProducto,
                        cantidad = item.cantidad,
                        precio = item.precio,
                        fechaCompra = item.fechaCompra,
                    });
                }

                if(await _transactionsRepository.SaveTransaction(transaction) > 0)
                {
                    Console.WriteLine("imon");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
