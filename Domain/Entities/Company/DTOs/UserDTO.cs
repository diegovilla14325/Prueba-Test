using Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.Company.DTOs
{
    public class UserDTO
    {
        public UserDTO()
        {
            diaRegistro = DateTime.Now;
            point = new List<PointDTO>();
        }

        [Key]
        public string correoUsuario { get; set; }

        public string contraseña { get; set; }
        [JsonIgnore]
        public DateTime diaRegistro { get; set; }


        public List<PointDTO> point { get; set; }


    }
}
