using Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company
{
    [Table("comprasrealizadas")]
    public class Transaction
    {
        public Transaction()
        {
            transactionLogs=new List<TransactionLog>(); 
        }

        [Key]
        public int idCompra { get; set; }

        public DateTime fechaCompra { get; set; }


        [ForeignKey("idUsuario")]
        public int idUsuario { get; set; }
        public virtual User users { get; set; }


        public double TotalCompra { get; set; }

        public virtual ICollection<TransactionLog> transactionLogs { get; set; }
    }
}
