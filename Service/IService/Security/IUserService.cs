using Domain.Entities.Company.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService.Security
{
    public interface IUserService
    {
        Task RegisterUser(UserDTO userdto);
        Task<List<UserPointsDTO>> GetUserDetail(int id_Usuario);
        Task<List<LoginDTO>> GetUser(string nombreUsuario, string contraseña);
    }
}
