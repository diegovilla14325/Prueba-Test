using Domain.Entities.Company.DTOs;
using Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Security
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<LoginDTO>> GetUser(string nombreUsuario, string contraseña)
        {
            var userId = await _dbContext.LoginDTOs.FromSqlInterpolated($"Call Login({nombreUsuario},{contraseña})").ToListAsync();
            return userId;
        }
        public async Task<List<UserPointsDTO>> GetUserDetail(int id_Usuario)
        {
            var userId = await _dbContext.UserPointsDTOs.FromSqlInterpolated($"Call DatosUsuario({id_Usuario})").ToListAsync();
            return userId;
        }
        public async Task<int> RegisterUser(User user)
        {
            _dbContext.Users.Add(user);
            return _dbContext.SaveChanges();
        }
    }
}
