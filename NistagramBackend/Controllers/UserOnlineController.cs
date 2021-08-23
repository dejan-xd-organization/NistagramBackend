using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramBackend.Helper;
using NistagramBackend.Model;
using NistagramUtils.DTO;

namespace NistagramBackend.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UserOnlineController : ControllerBase
    {
        readonly OfflineApi api = new OfflineApi();

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

        //private async Task<bool> SaveJWT(LoginResponseDTO lrDTO)
        //{
        //    HttpClient client = api.Initial();

        //    CreateNewSession cns = new CreateNewSession(lrDTO.user, lrDTO.jwt);
        //    var json = JsonConvert.SerializeObject(cns);
        //    var data = new StringContent(json, Encoding.UTF8, "application/json");
        //    var res = await client.PostAsync("Session/add-online-user", data);

        //    if (res.IsSuccessStatusCode)
        //    {
        //        var response = res.Content.ReadAsStringAsync().Result;
        //        Console.WriteLine(response);
        //    }
        //    return true;
        //}
    }
}
