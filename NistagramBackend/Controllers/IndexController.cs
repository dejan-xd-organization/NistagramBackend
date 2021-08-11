using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NistagramUtils.Offline.Post;
using NistagramUtils.Offline.Post.Model;
using Microsoft.Practices.Unity;

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : Controller
    {

        public IPostServices PostServices;

        public IndexController(IPostServices postServices)
        {
            PostServices = postServices;
        }

        [HttpGet]
        [HttpGet("allOptions")]
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
        [HttpGet("allOfflinePosts")]
        public HashSet<OfflinePost> GetAllOfflinePosts()
        {
            HashSet<OfflinePost> offlinePosts = PostServices.GetAllOfflinePosts();
            return offlinePosts;
        }

        [HttpGet]
        [HttpGet("allNewUsers")]
        public HashSet<User> GetAllNewUsers()
        {
            HashSet<User> newUsers = PostServices.GetAllNewUsers();
            return newUsers;
        }


    }
}
