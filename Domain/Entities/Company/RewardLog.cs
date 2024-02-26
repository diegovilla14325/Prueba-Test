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
    [Table("premioscanjeados")]
    public class RewardLog
    {
        [Key]
        public int idPremioCanjeado {  get; set; }

        [ForeignKey("idPremio")]
        public int idPremio {  get; set; }
        public virtual Reward rewards { get; set; }

        [ForeignKey("idUsuario")]
        public int idUsuario { get; set; }
        public virtual User users { get; set; }

        public DateTime fechaCanje { get; set; }

    }
}
