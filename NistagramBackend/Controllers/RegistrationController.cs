using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramSQLConnection.Model;
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
        private readonly IMapper _mapper;


        public RegistrationController(IUserService iUserService, IMapper mapper)
        {
            _iUserService = iUserService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/[action]")]
        public Object Registration(RegistrationDTO regDTO)
        {
            LoginResponseDTO lrDTO = new LoginResponseDTO();
            regDTO.dateOfRegistration = DateTime.Now;
            var mapperUser = _mapper.Map<User>(regDTO);
            bool response = _iUserService.RegistrationUser(mapperUser);
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