using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using Microsoft.Extensions.Logging;
using Azure.Functions.Domain;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Azure.Functions
{
    public static class GetNarsCalls
    {
        /// <summary>
        /// This is the HttpTrigger Version of the GetCalls Azure Function.  This would be called directly.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("GetCalls")]
        public static string Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            NarsHttpResponseObject result = new NarsHttpResponseObject();

            log.Info("GetCalls HttpTrigger executing...");

            var input = req.Content.ReadAsStringAsync().Result;

            var response = NarsCaller.Execute(Environment.GetEnvironmentVariable("callsUrl"), input);
            var responseResult = response.Content.ReadAsStringAsync().Result;

            JObject joResult = (JObject)JsonConvert.DeserializeObject(responseResult);

            if (response.IsSuccessStatusCode)
            {
                log.Info("****SUCCESS****");

                result = new NarsHttpResponseObject
                {
                    ReturnType = "List<NarsCall>",
                    ReturnObject = JsonConvert.DeserializeObject<List<NarsCall>>(joResult["d"]["Calls"].ToString()),
                    Success = true,
                    Exception = null
                };
            }
            else
            {
                log.Warning(responseResult);

                result = new NarsHttpResponseObject
                {
                    ReturnType = "HttpResponse.Content.ToString()",
                    ReturnObject = responseResult,
                    Success = false,
                    Exception = null,
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
        public static string GetCalls([ActivityTrigger] string content, ILogger log)
        {
            NarsHttpResponseObject result = new NarsHttpResponseObject();

            log.LogInformation("GetCalls ActivityTrigger executing...");

            var response = NarsCaller.Execute(Environment.GetEnvironmentVariable("callsUrl"), content);
            var responseResult = response.Content.ReadAsStringAsync().Result;

            JObject joResult = (JObject)JsonConvert.DeserializeObject(responseResult);

            if (response.IsSuccessStatusCode)
            {
                log.LogInformation("****SUCCESS****");

                result = new NarsHttpResponseObject
                {
                    ReturnType = "List<NarsCall>",
                    ReturnObject = JsonConvert.DeserializeObject<List<NarsCall>>(joResult["d"]["Calls"].ToString()),
                    Success = true,
                    Exception = null
                };
            }
            else
            {
                log.LogWarning(responseResult);

                result = new NarsHttpResponseObject
                {
                    ReturnType = "HttpResponse.Content.ToString()",
                    ReturnObject = responseResult,
                    Success = false,
                    Exception = null,
                };
            }


            return JsonConvert.SerializeObject(result);
        }
    }
}
