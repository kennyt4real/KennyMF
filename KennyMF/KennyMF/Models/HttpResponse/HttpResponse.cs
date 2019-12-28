using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Models.HttpResponse
{
    public class HttpResponse<T>
    {
        [JsonProperty("version")]
        public string Version => "2.0.0";

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
