using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company.DTOs
{
    public class RewardLogDTO
    {
        [Key]
        public int idPremio { get; set; }

        public int idUsuario { get; set; }

        public DateTime fechaCanje { get; set; }
    }
}
