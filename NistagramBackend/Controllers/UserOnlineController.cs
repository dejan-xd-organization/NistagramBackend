using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramBackend.Helper;
using NistagramUtils.DTO.Follower;
using NistagramUtils.DTO.WallPost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NistagramBackend.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserOnlineController : ControllerBase
    {
        readonly ApiGateway api = new ApiGateway();

        // WALL POSTS //

        [HttpGet]
        [Route("/[action]")]
        public async Task<List<WallPostDto>> GetAllOnlineWallPosts()
        {
            List<WallPostDto> postDTO = new List<WallPostDto>();
            HttpClient client = api.InitialOnline();
            var res = await client.GetAsync("GetAllWallPosts");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                postDTO = JsonConvert.DeserializeObject<List<WallPostDto>>(response);
            }
            return postDTO;
        }


        // FOLLOWERS //

        [HttpPost]
        [Route("/[action]")]
        public async Task<bool> AddNewFollower(NewFollower newFollower)
        {
            HttpClient client = api.InitialOnline();
            var json = JsonConvert.SerializeObject(newFollower);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("AddNewFollower", data);
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                Console.WriteLine(response);
            }
            return true;
        }

    }
}
