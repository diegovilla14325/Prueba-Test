using Domain.Entities.Company.DTOs;
using Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.IService.Security;
using Service.Service.Company;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LealtadAPI.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserResponseAuth>> Login(UserCredentials userCredentials)
        {
            var response = await _userService.GetUser(userCredentials.Email, userCredentials.Password);
            if (!response.Any())
            {
                return BadRequest("Los datos no son correctos");
            }

            //Codigo
            return await BuildToken(userCredentials);

            //return Ok(response);
        }

        [HttpGet]
        [Route("GetUserDetail")]
        public async Task<IActionResult> GetUserDetail(int id_Usuario)
        {
            var response = await _userService.GetUserDetail(id_Usuario);
            if (!response.Any())
            {
                return BadRequest("No existe ese usuario");
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO userdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ingrese los datos correspondientes");

            }
            var response = _userService.RegisterUser(userdto);
            return Ok(response);
        }

        private async Task<UserResponseAuth> BuildToken(UserCredentials userCredentials)
        {
            var User = await _userService.GetUser(userCredentials.Email, userCredentials.Password);
            var Claims = new List<Claim>();

            if (User.Any())
            {
                var userData = User.First();
                var userDataClaims = new List<Claim>()
                {
                    new Claim("id", userData.idUsuario.ToString()),
                    new Claim("email", userData.correoUsuario),
                    new Claim("fecha", userData.diaRegistro.ToString()),


                };
                Claims.AddRange(userDataClaims);
            }
            else
            {
                var userDataClaims = new List<Claim>()
            {
                new Claim("email", userCredentials.Email),
            };
                Claims.AddRange(userDataClaims);
            }


            var Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var StringChars = new char[32];
            var Random = new Random();

            for (int i = 0; i < StringChars.Length; i++)
            {
                StringChars[i] = Chars[Random.Next(Chars.Length)];
            }

            var FinalString = StringChars;

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(FinalString));
            var Credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var Expiration = DateTime.UtcNow.AddMinutes(30);

            var Token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: Claims,
                expires: Expiration,
                signingCredentials: Credentials
            );
            var TokenString = new JwtSecurityTokenHandler().WriteToken(Token);

            return new UserResponseAuth()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(Token),
                Expiration = Expiration
            };

            //Aqui aplicamos logica interna -> Se almacene en BDD

        }
    }
}
