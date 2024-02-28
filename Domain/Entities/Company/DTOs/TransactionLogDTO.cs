using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company.DTOs
{
    public class TransactionLogDTO
    {
        
        public int idProducto { get; set; }

        public int cantidad { get; set; }

        public double precio { get; set; }

        public DateTime fechaCompra { get; set; }
    }
}
