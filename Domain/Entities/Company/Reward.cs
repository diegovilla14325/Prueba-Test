using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company
{
    [Table("premios")]
    public class Reward
    {
        public Reward() { 
         rewardLogs = new List<RewardLog>();
        }
        [Key]
        public int idPremio { get; set; }

        public string nombrePremio { get; set; }

        public int ValorEnPuntos { get; set; }

        public virtual ICollection<RewardLog> rewardLogs { get; set; }
    }
}
