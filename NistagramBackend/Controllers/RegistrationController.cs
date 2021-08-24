using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using NistagramUtils.DTO;
using NistagramUtils.DTO.Register;
using System;

namespace NistagramBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
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
        public Object Registration(RegistrationDto regDTO)
        {
            LoginResponseDto lrDTO = new LoginResponseDto();
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
            return JsonConvert.SerializeObject(lrDTO);
        }
    }
}