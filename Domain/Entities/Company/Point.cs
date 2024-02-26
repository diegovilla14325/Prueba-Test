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
    [Table("puntos")]
    public class Point
    {
    
        [Key]
        public int idPuntos {  get; set; }

        [ForeignKey("idUsuario")]
        public int IdUsuario { get; set; }
        public virtual User users { get; set; }

        public int cantidad { get; set; }

  
    }
}
