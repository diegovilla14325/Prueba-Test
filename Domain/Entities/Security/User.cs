using Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.Security
{
    [Table("usuarios")]
    public class User
    {   public User()
        {
            transactions = new List<Transaction>();
            point = new List<Point>();
            rewardLogs= new List<RewardLog>();
        }

        [Key]
        public int idUsuario {  get; set; }

        public string correoUsuario { get; set; }

        public string contraseña { get; set; }

        public DateTime diaRegistro { get; set; }
        [JsonIgnore]
        public virtual ICollection<Transaction> transactions { get; set; }
        [JsonIgnore]
        public virtual ICollection<Point> point { get; set; }
        [JsonIgnore]
        public virtual ICollection<RewardLog> rewardLogs { get; set; }
    }
}
