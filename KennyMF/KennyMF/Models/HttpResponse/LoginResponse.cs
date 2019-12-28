using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Models.HttpResponse
{
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("user_teams")]
        public List<string> UserTeams { get; set; }
    }
}
