using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReactDotnet.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ReactDotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StuffController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    //docker ps --format='{"Names":{{json .Names}},"Ports": {{json .Ports}},"Image": {{json .Image}}}'
                    FileName = "/usr/bin/docker",
                    Arguments = $"\"ps \"",
                    // FileName = "/bin/bash",
                    // Arguments = $"-c \"pwd\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            string prettyResult = Resulter(result);

            Console.WriteLine(prettyResult);
            
            return new List<string>{prettyResult};
        }

        public static string Resulter(string uglyThing)
        {
            Container cat = JsonSerializer.Deserialize<Container>(uglyThing);
            return JsonSerializer.Serialize(cat);

        }
    }
}