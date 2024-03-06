using Domain.Entities.Company;
using Domain.Entities.Company.DTOs;
using Domain.Entities.Security;
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

        
        
        public async Task SaveTransaction(TransactionDTO transactiondto)
        {
            

            try
            {
                var transaction = new Transaction()
                {
                    idUsuario = transactiondto.idUsuario,
                    fechaCompra = transactiondto.fechaCompra,
                    TotalCompra = transactiondto.totalCompra,
                    PuntosObtenidos = Convert.ToInt32((transactiondto.totalCompra) / 2),
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
                    Console.WriteLine("Compra realizada");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
