using Domain.Entities.Company;
using Domain.Entities.Company.DTOs;
using Domain.Entities.Security;
using Repository.Repositories.Security;
using Service.IService.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Security
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<LoginDTO>> GetUser(string nombreUsuario, string contraseña)
        {
            var users = new List<LoginDTO>();
            try
            {
                users = await _userRepository.GetUser(nombreUsuario, contraseña);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return users;
        }
        public async Task<List<UserPointsDTO>> GetUserDetail(int id_Usuario)
        {
            var users = new List<UserPointsDTO>();
            try
            {
                users = await _userRepository.GetUserDetail(id_Usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return users;
        }
        public async Task RegisterUser(UserDTO userdto)
        {
            try
            {
                var user = new User();
                {
                    user.correoUsuario = userdto.correoUsuario;
                    user.contraseña = userdto.contraseña;
                    user.diaRegistro = DateTime.Now;
                };
                foreach (var item in userdto.point)
                {
                    user.point.Add(new Point()
                    {
                        cantidad = item.cantidad,
                    });
                }


                if (await _userRepository.RegisterUser(user) > 0)
                {
                    Console.WriteLine("Registro realizado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
