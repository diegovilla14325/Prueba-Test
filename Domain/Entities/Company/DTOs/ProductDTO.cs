using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company.DTOs
{
    public class ProductDTO
    {
        [Key]
        public int idProducto { get; set; }

        public string nombreProducto { get; set; }

        public double precio { get; set; }

        public virtual ICollection<TransactionLog> transactionLogs { get; set; }
    }
}

