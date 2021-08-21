using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramBackend.Helper;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using NistagramUtils.DTO;
using NistagramBackend.Model;
using System.Net.Http;

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserOfflineController : ControllerBase
    {
        OfflineApi api = new OfflineApi();

        [HttpGet]
        [Route("/[action]")]
        public async Task<List<Model.UserDTO>> FilterUser(string filter)
        {
            List<Model.UserDTO> userDTO = new List<Model.UserDTO>();
            HttpClient client = api.Initial();
            var res = await client.GetAsync("FilterUser?filter=" + filter);
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                userDTO = JsonConvert.DeserializeObject<List<Model.UserDTO>>(response);
            }
            return userDTO;
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<List<Model.UserDTO>> FindNewUsers()
        {
            List<Model.UserDTO> userDTO = new List<Model.UserDTO>();
            HttpClient client = api.Initial();
            var res = await client.GetAsync("FindNewUsers");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                userDTO = JsonConvert.DeserializeObject<List<Model.UserDTO>>(response);
            }
            return userDTO;
        }

        [HttpGet]
        [Route("/[action]")]
        public async Task<List<Model.WallPostDTO>> GetAllPosts()
        {
            List<Model.WallPostDTO> postDTO = new List<Model.WallPostDTO>();
            HttpClient client = api.Initial();
            var res = await client.GetAsync("GetAllPosts");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                postDTO = JsonConvert.DeserializeObject<List<Model.WallPostDTO>>(response);
            }
            return postDTO;
        }
    }
}
