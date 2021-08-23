using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using NistagramUtils.DTO;
using NistagramUtils.JWT;
using System;

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _iUserService;

        public LoginController(IUserService iUserService)
        {
            _iUserService = iUserService;
        }

        [HttpPost]
        [Route("/[action]")]
        public Object Login(LoginDto loginDTO)
        {
            LoginResponseDto lrDTO = new LoginResponseDto();
            User user = _iUserService.LoginUser(loginDTO.username, loginDTO.password);

            if (user == null)
            {
                lrDTO.status = "login_user_null";
                return JsonConvert.SerializeObject(lrDTO);
            }
            string jwt = JwtToken.GenerateJSONWebToken(user);

            JwtService.AddActiveUser(jwt, user);

            lrDTO.status = "SUCCESS";
            lrDTO.jwt = jwt;
            lrDTO.userDTO = new UserDto(user);

            return JsonConvert.SerializeObject(lrDTO);
        }
    }
}
