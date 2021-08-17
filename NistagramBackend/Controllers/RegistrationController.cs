using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramSQLConnection.Service.Interface;
using NistagramUtils.DTO;
using NistagramUtils.DTO.Register;

namespace NistagramBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly IUserService _iUserService;

        public RegistrationController(IUserService iUserService)
        {
            _iUserService = iUserService;
        }

        [HttpPost]
        [Route("/[action]")]
        public Object Registration(RegistrationDTO regDTO)
        {
            LoginResponseDTO lrDTO = new LoginResponseDTO();
            regDTO.dateOfRegistration = DateTime.Now;
            bool response = _iUserService.RegistrationUser(regDTO.firstName, regDTO.lastName, regDTO.username, regDTO.email,
             regDTO.password, regDTO.sex, regDTO.dateOfBirth, regDTO.dateOfRegistration);
            if (!response)
            {
                lrDTO.status = "registration_error";
            }
            else
            {
                lrDTO.status = "registration_success";
            }
            return JsonConvert.SerializeObject(lrDTO); ;
        }
    }
}
