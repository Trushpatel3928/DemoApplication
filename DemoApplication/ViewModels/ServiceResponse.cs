using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DemoApplication.ViewModels
{
    public class ServiceResponse<T> where T : class
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("statusCode")]
        public HttpStatusCode StatusCode { get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }
        [JsonProperty("result")]
        public T? Result { get; set; }
    }
}
