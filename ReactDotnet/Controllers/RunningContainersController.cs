using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReactDotnet.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ReactDotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RunningContainersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var result = RunProcess();
            var runningContainersList = ParsesRunningContainers(result);
            var prettyResult = JsonMagick(runningContainersList);

            return prettyResult;
        }

        public static List<Container> ParsesRunningContainers(string psResults)
        {
            if (string.IsNullOrEmpty(psResults)) 
            {
                return null;
            }
            
            if (psResults.Contains('\n'))
            {
                var multipleRunning = psResults.Trim().Split('\n').ToList();
                var results = new List<Container>();
                foreach (var running in multipleRunning)
                {
                    results.Add(SingleResulter(running));
                }

                return results;
            }

            return new List<Container> {SingleResulter(psResults)};
        }
        
        public static string JsonMagick(List<Container> containers)
        {
            var thing = new
            {
                Other = containers
            };
            return JsonSerializer.Serialize(thing);
        }

        private static Container SingleResulter(string psResults)
        {
           
            var splitResults = psResults.Split(',');
            var candidate = new
            {
                Names = splitResults.ElementAt(0).Split(':').ElementAt(1) ?? "",
                Ports = PortChecker(splitResults.ElementAt(1)),
                Image = splitResults.ElementAt(2).Split(':').ElementAt(1) ?? "",
            };

            var jsonDog = JsonConvert.SerializeObject(candidate);
            return JsonSerializer.Deserialize<Container>(jsonDog);
        }
        
        private string RunProcess()
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/usr/bin/docker",
                    Arguments = $"ps --format name:{{{{.Names}}}},ports:{{{{.Ports}}}},image:{{{{.Image}}}}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }

        private static string PortChecker(string address) =>
            address.Split(':')
                .ElementAt(address.Contains('>') ? 2 : 1) ?? "";
        
    }
}