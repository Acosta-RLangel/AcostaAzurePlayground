using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System;
using Microsoft.Extensions.Logging;
using Azure.Functions.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Azure.Functions
{
    public static class GetNarsUser
    {
        /// <summary>
        /// This is the HttpTrigger Version of the GetNarsUser Azure Function.  This would be called directly.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns>NarsHttpResponseObject containing the object</returns>
        [FunctionName("GetNarsUser")]
        public static string Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            NarsHttpResponseObject result = new NarsHttpResponseObject();

            log.Info("GetNarsUser HttpTrigger executing...");

            var content = req.Content.ReadAsStringAsync().Result;

            var response = NarsCaller.Execute(Environment.GetEnvironmentVariable("userUrl"), content);

            var responseResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                log.Info("****SUCCESS****");

                JObject respResult = (JObject)JsonConvert.DeserializeObject(responseResult);

                result = new NarsHttpResponseObject
                {
                    ReturnType = "NarsUser",
                    ReturnObject = JsonConvert.DeserializeObject<NarsUser>(respResult["d"].ToString()),
                    Success = true,
                    Exception = null
                };
            }
            else
            {
                log.Warning(responseResult);
                result = new NarsHttpResponseObject
                {
                    ReturnType = "HttpResponse.Content.ToString",
                    ReturnObject = responseResult,
                    Success = false,
                    Exception = null
                };
            }

            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// This is the ACTIVITY trigger version of the GetNarsUser Azure Function.  This would be called by an Orchestrator.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static string CallNarsUser([ActivityTrigger] string content, ILogger log)
        {
            NarsHttpResponseObject result = new NarsHttpResponseObject();

            log.LogInformation("GetNarsUser ActivityTrigger executing...");

            var response = NarsCaller.Execute(Environment.GetEnvironmentVariable("userUrl"), content);
            var responseResult = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                log.LogInformation("****SUCCESS****");

                JObject respResult = (JObject)JsonConvert.DeserializeObject(responseResult);

                result = new NarsHttpResponseObject
                {
                    ReturnType = "NarsUser",
                    ReturnObject = JsonConvert.DeserializeObject<NarsUser>(respResult["d"].ToString()),
                    Success = true,
                    Exception = null
                };
            }
            else
            {
                log.LogWarning(responseResult);
                result = new NarsHttpResponseObject
                {
                    ReturnType = "HttpResponse.Content.ToString",
                    ReturnObject = responseResult,
                    Success = false,
                    Exception = null
                };
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}
