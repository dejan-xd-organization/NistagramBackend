﻿using Newtonsoft.Json;

namespace NistagramBackend.Model
{
    public class UserDto
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("img")]
        public string img { get; set; }
    }
}
