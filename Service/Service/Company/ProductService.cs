using Domain.Entities.Company.DTOs;
using Domain.Entities.Company;
using Repository.Repositories.Company;
using Service.IService.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Company
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDTO>> GetProducts()
        {
            var Products = new List<ProductDTO>();

            try
            {
                Products = await _productRepository.GetProducts();
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
                Products = await _productRepository.GetProductById(idProducto);
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

                if (await _productRepository.CreatedProduct(product) > 0)
                {
                    Console.WriteLine("Se agrego el producto");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
