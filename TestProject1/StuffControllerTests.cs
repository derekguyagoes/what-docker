using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ReactDotnet.Controllers;
using ReactDotnet.Models;
using Shouldly;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestProject1
{
    public class StuffControllerTests
    {
        [Test]
        public void Initial()
        {
            var json = "name:fervent_nobel,ports:80/tcp,image:nginx";
             // {"Image":"nginx","Names":"fervent_nobel","Ports":"80/tcp"}

//            name:fervent_nobel,ports:80/tcp,image:nginx

            var result = RunningContainersController.Resulter(json);
            var resultContainer = JsonSerializer.Deserialize<Container>(result);
            resultContainer.Image.ShouldBe("nginx");
            resultContainer.Names.ShouldBe("fervent_nobel");

        }

        [Test]
        public void TestGet()
        {
            string json =
                @"name:competent_haibt,ports:80/tcp,image:nginx
                   name:loving_lamarr,ports:0.0.0.0:80->80/tcp,image:ninja";
            var result = RunningContainersController.Resulter(json);
            
            var resultContainer = JsonSerializer.Deserialize<List<Container>>(result);
            resultContainer.Count.ShouldBe(2);
            resultContainer.First().Names.ShouldBe("competent_haibt");
            resultContainer.ElementAt(1).Image.ShouldBe("ninja");
            

        }
    }
}