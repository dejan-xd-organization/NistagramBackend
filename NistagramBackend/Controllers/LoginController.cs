using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using NistagramUtils.DTO;
using NistagramUtils.JWT;

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _iUserService;
        private readonly JWTToken jwtToken = new JWTToken();

        public LoginController(IUserService iUserService)
        {
            _iUserService = iUserService;
        }

        [HttpPost]
        [Route("/[action]")]
        public Object Login(LoginDTO loginDTO)
        {
            LoginResponseDTO lrDTO = new LoginResponseDTO();
            User user = _iUserService.LoginUser(loginDTO.username, loginDTO.password);

            if (user == null)
            {
                lrDTO.status = "login_user_null";
                return JsonConvert.SerializeObject(lrDTO);
            }
            string jwt = this.jwtToken.GenerateJSONWebToken(user);

            JWTService.AddActiveUser(jwt, user);

            lrDTO.status = "SUCCESS=succes";
            lrDTO.jwt = jwt;
            lrDTO.userDTO = new UserDTO(user);

            return JsonConvert.SerializeObject(lrDTO);
        }
    }
}
