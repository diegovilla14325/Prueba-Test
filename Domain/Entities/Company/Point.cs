using Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.Company
{
    [Table("puntos")]
    public class Point
    {
    
        [Key]
        public int idPuntos {  get; set; }

        [ForeignKey("users")]
        public int IdUsuario { get; set; }
        [JsonIgnore]
        public virtual User users { get; set; }

        public int cantidad { get; set; }

  
    }
}
