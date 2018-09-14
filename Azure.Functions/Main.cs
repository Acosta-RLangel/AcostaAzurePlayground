using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Functions.Domain;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Azure.Functions
{
    public static class Main
    {
        [FunctionName("MyFunction_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]HttpRequestMessage req,
            [OrchestrationClient]DurableOrchestrationClient starter,
            ILogger log)
        {
            string content = req.Content.ReadAsStringAsync().Result;
            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync("MyFunction", content);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }

        [FunctionName("MyFunction")]
        public static async Task<string> RunOrchestrator(
            [OrchestrationTrigger] DurableOrchestrationContext context)
        {
            var Tasks1 = new List<Task<string>>();
            var parallelTasks = new List<Task<string>>();

            string content = context.GetInput<string>();

            Task<string> task = context.CallActivityAsync<string>("CallNarsUser", content);
            Tasks1.Add(task);
            await Task.WhenAll(Tasks1);

            JObject JSONObj = (JObject)JsonConvert.DeserializeObject(content);
            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            var user = new User
            {
                OriginInfo = new OriginInfo
                {
                    UserName = "meiadmin",
                    LocalDate = DateTime.UtcNow
                },
                UserName = (string)JSONObj["userName"],
                Force = false,
                CallStatus = 2

            };
            var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(user, microsoftDateFormatSettings);

            // Replace "hello" with the name of your Durable Activity Function.
            Task<string> task1 = context.CallActivityAsync<string>("GetCalls", user);
            //Task<string> task2 =  context.CallActivityAsync<string>("MyFunction_Second", "Seattle");
            //Task<string> task3 =  context.CallActivityAsync<string>("MyFunction_Third", "London");

            parallelTasks.Add(task1);
            //parallelTasks.Add(task2);
            //parallelTasks.Add(task3);            

            await Task.WhenAll(parallelTasks);
            return parallelTasks[0].Result;

        }
    }
}
