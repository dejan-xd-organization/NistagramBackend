using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramBackend.Helper;
using NistagramUtils.DTO.Chat;

namespace NistagramBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {

        readonly ApiGateway api = new ApiGateway();

        [HttpGet]
        [Route("/[action]")]
        public async Task<string> GetChatByUser(long friendId, long userId)
        {
            HttpClient client = api.InitialChat();
            var res = await client.GetAsync("GetChatByUser?friendId=" + friendId + "&userId=" + userId);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
            }
            return response;
        }

        [HttpPost]
        [Route("/[action]")]
        public async Task<string> SendMessage(SendMessageDto sendMessageDto)
        {
            HttpClient client = api.InitialChat();
            var json = JsonConvert.SerializeObject(sendMessageDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("SendMessage", data);
            string response = "";
            if (res.IsSuccessStatusCode)
            {
                response = res.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(response);
            }
            return response;
        }
    }
}
