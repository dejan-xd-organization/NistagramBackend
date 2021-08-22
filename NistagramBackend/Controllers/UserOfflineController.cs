using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramBackend.Helper;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserOfflineController : ControllerBase
    {
        readonly OfflineApi api = new OfflineApi();

        [HttpGet]
        [Route("/[action]")]
        public async Task<List<Model.UserDto>> FilterUser(string filter)
        {
            List<Model.UserDto> userDTO = new List<Model.UserDto>();
            HttpClient client = api.Initial();
            var res = await client.GetAsync("FilterUser?filter=" + filter);
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                userDTO = JsonConvert.DeserializeObject<List<Model.UserDto>>(response);
            }
            return userDTO;
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<List<Model.UserDto>> FindNewUsers()
        {
            List<Model.UserDto> userDTO = new List<Model.UserDto>();
            HttpClient client = api.Initial();
            var res = await client.GetAsync("FindNewUsers");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                userDTO = JsonConvert.DeserializeObject<List<Model.UserDto>>(response);
            }
            return userDTO;
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<List<Model.WallPostDto>> GetAllPosts()
        {
            List<Model.WallPostDto> postDTO = new List<Model.WallPostDto>();
            HttpClient client = api.Initial();
            var res = await client.GetAsync("GetAllPosts");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                postDTO = JsonConvert.DeserializeObject<List<Model.WallPostDto>>(response);
            }
            return postDTO;
        }
    }
}
