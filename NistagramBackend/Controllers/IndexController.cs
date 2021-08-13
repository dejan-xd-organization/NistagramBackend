using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NistagramBackend.Services.Intefrace;
using NistagramSQLConnection.Service.Interface;
using NistagramUtils.DTO;
using NistagramUtils.Offline.Post;
using NistagramUtils.Offline.Post.Model;

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {

        private IIndexService _indexService;

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
            newOption.Add("options",publicOptions);
            return newOption;
        }

        [HttpGet]
        [Route("/[action]")]
        public HashSet<OfflinePost> GetAllOfflinePosts()
        {
            //HashSet<OfflinePost> offlinePosts = _userService.GetAllOfflinePosts();
            return null;
        }

        [HttpGet]
        [Route("/[action]")]
        public List<UserDTO> GetAllNewUsers()
        {
            return _indexService.GetAllUsers();
        }


    }
}
