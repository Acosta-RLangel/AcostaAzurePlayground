using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Azure.Functions.Domain
{
    public static class NarsCaller
    {
        public static HttpResponseMessage Execute(string url, string content)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("serviceBaseAddress"));

            HttpContent requestBody = new StringContent(content, Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, requestBody).Result;
            return result;
        }
    }
}
