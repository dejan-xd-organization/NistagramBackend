using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramBackend.Helper;
using NistagramUtils.DTO;

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserOfflineController : ControllerBase
    {
        readonly ApiGateway api = new ApiGateway();

        [HttpGet]
        [Route("/[action]")]
        public async Task<List<UserOnlineJsonDto>> FilterUser(string filter)
        {
            List<UserOnlineJsonDto> userDTO = new List<UserOnlineJsonDto>();
            HttpClient client = api.InitialOffline();
            var res = await client.GetAsync("FilterUser?filter=" + filter);
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                userDTO = JsonConvert.DeserializeObject<List<UserOnlineJsonDto>>(response);
            }
            return userDTO;
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<List<UserOnlineJsonDto>> FindNewUsers()
        {
            List<UserOnlineJsonDto> userDTO = new List<UserOnlineJsonDto>();
            HttpClient client = api.InitialOffline();
            var res = await client.GetAsync("FindNewUsers");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                userDTO = JsonConvert.DeserializeObject<List<UserOnlineJsonDto>>(response);
            }
            return userDTO;
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<string> GetAllOfflineWallPosts()
        {
            HttpClient client = api.InitialOffline();
            var res = await client.GetAsync("GetAllWallPosts");
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;
        }
    }
}
