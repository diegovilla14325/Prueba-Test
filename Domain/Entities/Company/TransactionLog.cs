using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company
{
    [Table("detallescomprasrealizadas")]
    public class TransactionLog
    {
        [Key]
        public int idDetalleCOmpra {  get; set; }

        [ForeignKey("transactions")]
        public int idCompra { get; set; }
        public virtual Transaction transactions { get; set; }

        [ForeignKey("products")]
        public int idProducto { get; set; }
        public virtual Product products { get; set; }

        public int cantidad {  get; set; }

        public double precio { get; set; }

        public DateTime fechaCompra { get; set; }
    }
}
