using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Models
{
    public class LoginModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }    
    }
}
