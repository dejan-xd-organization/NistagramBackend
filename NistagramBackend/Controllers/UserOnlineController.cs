using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramBackend.Helper;
using NistagramUtils.DTO.Follower;
using NistagramUtils.DTO.User;
using NistagramUtils.DTO.WallPost;

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
        public async Task<string> GetAllOnlineWallPosts()
        {
            HttpClient client = api.InitialOnline();
            var res = await client.GetAsync("GetAllWallPosts");
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;
        }

        [HttpPut]
        [Route("/[action]")]
        public async Task<bool> Like(ReactionDto reactionDto)
        {
            HttpClient client = api.InitialOnline();
            reactionDto.type = true;
            var json = JsonConvert.SerializeObject(reactionDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("PutReaction", data);
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        [HttpPut]
        [Route("/[action]")]
        public async Task<bool> Dislike(ReactionDto reactionDto)
        {
            HttpClient client = api.InitialOnline();
            reactionDto.type = false;
            var json = JsonConvert.SerializeObject(reactionDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("PutReaction", data);
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("/[action]")]
        public async Task<string> NewPost(PostDto postDt)
        {
            HttpClient client = api.InitialOnline();
            var json = JsonConvert.SerializeObject(postDt);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("NewPost", data);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;
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

        [HttpGet]
        [Route("/[action]")]
        public async Task<string> GetMyFollowers(string id, int page)
        {
            HttpClient client = api.InitialOnline();
            var res = await client.GetAsync("GetMyFollowers?id=" + id + "&page=" + page);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<string> GetMyFollowing(string id, int page)
        {
            HttpClient client = api.InitialOnline();
            var res = await client.GetAsync("GetMyFollowing?id=" + id + "&page=" + page);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;
        }


        [HttpGet]
        [Route("/[action]")]
        public async Task<string> GetNewFollowers(string id)
        {
            HttpClient client = api.InitialOnline();
            var res = await client.GetAsync("GetNewFollowers?id=" + id);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<string> GetNewFollowings(string id)
        {
            HttpClient client = api.InitialOnline();
            var res = await client.GetAsync("GetNewFollowings?id=" + id);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;
        }


        // USER

        [HttpPut]
        [Route("/[action]")]
        public async Task<string> UpdateUser(UpdateUserDto updateUserDto)
        {
            HttpClient client = api.InitialOnline();
            var json = JsonConvert.SerializeObject(updateUserDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("UpdateUser", data);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;

        }

        [HttpPut]
        [Route("/[action]")]
        public async Task<string> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            HttpClient client = api.InitialOnline();
            var json = JsonConvert.SerializeObject(changePasswordDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("ChangePassword", data);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;

        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<string> GetMyOnlineWallPosts(string id)
        {
            HttpClient client = api.InitialOnline();
            var res = await client.GetAsync("GetMyOnlineWallPosts?id=" + id);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;
        }

    }
}