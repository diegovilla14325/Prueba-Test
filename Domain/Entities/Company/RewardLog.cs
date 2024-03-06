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
    [Table("premioscanjeados")]
    public class RewardLog
    {
        [Key]
        public int idPremioCanjeado {  get; set; }

        [ForeignKey("rewards")]
        public int idPremio {  get; set; }
        [JsonIgnore]
        public virtual Reward rewards { get; set; }

        [ForeignKey("users")]
        public int idUsuario { get; set; }
        [JsonIgnore]
        public virtual User users { get; set; }

        public DateTime fechaCanje { get; set; }

    }
}
