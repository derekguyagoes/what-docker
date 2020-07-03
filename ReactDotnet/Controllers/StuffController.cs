using System;
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
    public class StuffController : ControllerBase
    {
        [HttpGet]
        public string Get()
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
            string prettyResult = Resulter(result);

            return prettyResult;
        }

        public static string Resulter(string uglyThing)
        {
            var uglyThings = uglyThing.Split(',');
            var dog = new
            {
                Names = uglyThings.ElementAt(0).Split(':').ElementAt(1),
                Ports = uglyThings.ElementAt(1).Split(':').ElementAt(1),
                Image = uglyThings.ElementAt(2).Split(':').ElementAt(1),
            };

            var jsonDog = JsonConvert.SerializeObject(dog);
            var cat = JsonSerializer.Deserialize<Container>(jsonDog);
            return JsonSerializer.Serialize(cat);

        }
    }
}