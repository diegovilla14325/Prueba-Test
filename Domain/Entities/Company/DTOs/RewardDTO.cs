using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company.DTOs
{
    public class RewardDTO
    {
        [Key]
        public int idPremio { get; set; }
        public string nombrePremio { get; set; }

        public int ValorEnPuntos { get; set; }
    }
}
