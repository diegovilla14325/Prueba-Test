using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company
{
    [Table("productos")]

    public class Product
    {
        public Product() 
        {
            transactionLogs = new List<TransactionLog>();        
        }
        [Key]
        public int idProducto { get; set; }

        public string nombreProducto { get; set; }

        public double precio { get; set; }

        public virtual ICollection<TransactionLog> transactionLogs { get; set; }
    }
}
