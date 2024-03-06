using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company.DTOs
{
    public class TransactionDTO
    {
        public TransactionDTO() {
            transactionLogs = new List<TransactionLogDTO>();
        }
         public int idUsuario { get; set; }

        public DateTime fechaCompra { get; set; }

        public double totalCompra { get; set; }

        public int PuntosObtenidos { get; set; }

        public List<TransactionLogDTO> transactionLogs { get; set; }
    }
}
