using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Azure.Functions
{
    public static class GetNarsUser
    {
        /// <summary>
        /// This is the HttpTrigger Version of the GetNarsUser Azure Function.  This would be called directly.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("GetNarsUser")]
        public static string Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("GetNarsUser HttpTrigger executing...");

            var content = req.Content.ReadAsStringAsync().Result;

            var response = Execute(content);

            var result = response.Content.ReadAsStringAsync().Result;

            if(response.IsSuccessStatusCode)
            {
                log.Info(result);
            }
            else
            {
                log.Warning(result);
            }

            return result;
        }


        /// <summary>
        /// This is the ACTIVITY trigger version of the GetNarsUser Azure Function.  This would be called by an Orchestrator.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static string Call_GetNarsUser([ActivityTrigger] string content, ILogger log)
        {
            log.LogInformation("GetNarsUser ActivityTrigger executing...");

            var response = Execute(content);
            var result = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                log.LogInformation(result);
            }
            else
            {
                log.LogWarning(result);
            }

            return result;
        }

        /// <summary>
        /// The actual work for this call. Shared amongst both of the above exposed endpoints.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private static HttpResponseMessage Execute(string content)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(Environment.GetEnvironmentVariable("serviceBaseAddress"));
                var inputContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("/NarsUser.svc/json/GetNarsUser", inputContent).Result;
                return response;
            }

        }
    }
}
