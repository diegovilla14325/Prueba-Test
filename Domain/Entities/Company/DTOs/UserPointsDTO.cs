using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Company.DTOs
{
    public class UserPointsDTO
    {

        [Key]

        public int idUsuario {  get; set; }

        public string correoUsuario { get; set; }

        public int  cantidad { get; set; }
    }
}
