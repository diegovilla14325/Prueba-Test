using Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Security
{
    [Table("usuarios")]
    public class User
    {   public User()
        {
            transactions = new List<Transaction>();
            points = new List<Point>();
            rewardLogs= new List<RewardLog>();
        }

        [Key]
        public int idUsario {  get; set; }

        public string nombreUsuario { get; set; }

        public string contraseña { get; set; }

        public DateTime diaRegistro { get; set; }

        public virtual ICollection<Transaction> transactions { get; set; }

        public virtual ICollection<Point> points { get; set; }

        public virtual ICollection<RewardLog> rewardLogs { get; set; }
    }
}
