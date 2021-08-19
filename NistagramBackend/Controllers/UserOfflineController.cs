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

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserOfflineController : ControllerBase
    {
        private readonly IUserService _iUserService;
        private readonly IMapper _mapper;


        public UserOfflineController(IUserService iUserService, IMapper mapper)
        {
            _iUserService = iUserService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/[action]")]
        public Object FilterUser(string filter)
        {
            List<User> user = _iUserService.FilterUser(filter);
            var mapperUser = _mapper.Map<UserDTO[]>(user);
            return JsonConvert.SerializeObject(mapperUser);
        }
    }
}
