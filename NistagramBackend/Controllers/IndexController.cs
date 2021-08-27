using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NistagramBackend.Services.Intefrace;
using NistagramUtils.DTO;

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {

        private readonly IIndexService _indexService;

        public IndexController(IIndexService indexService)
        {
            _indexService = indexService;
        }

        [HttpGet]
        [Route("/[action]")]
        public Dictionary<String, List<String>> GetAllOptions()
        {
            Dictionary<String, List<String>> newOption = new Dictionary<string, List<string>>();
            List<String> publicOptions = new List<string>();
            publicOptions.Add("en");
            publicOptions.Add("30");
            newOption.Add("options", publicOptions);
            return newOption;
        }


        [HttpGet]
        [Route("/[action]")]
        public List<UserDto> GetAllNewUsers()
        {
            return _indexService.GetAllUsers();
        }


    }
}
