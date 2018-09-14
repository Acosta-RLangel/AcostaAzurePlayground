
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Text;
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
            log.Info("GetCalls HttpTrigger executing...");

            var input = req.Content.ReadAsStringAsync().Result;

            var response = NarsCaller.Execute(Environment.GetEnvironmentVariable("callsUrl"), input);
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                log.Info("****SUCCESS****");
            }
            else
            {
                log.Warning(responseData);
            }

            JObject joResult = (JObject)JsonConvert.DeserializeObject(responseData);

            List<NarsCall> result = JsonConvert.DeserializeObject<List<NarsCall>>(joResult["d"]["Calls"].ToString());
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
            log.LogInformation("GetCalls ActivityTrigger executing...");

            var response = NarsCaller.Execute(Environment.GetEnvironmentVariable("callsUrl"), content);
            var result = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                log.LogInformation("****SUCCESS****");
            }
            else
            {
                log.LogWarning(result);
            }
            return result;
        }
    }
}
