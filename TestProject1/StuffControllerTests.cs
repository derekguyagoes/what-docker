using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ReactDotnet.Controllers;
using ReactDotnet.Models;
using Shouldly;

namespace TestProject1
{
    public class StuffControllerTests
    {
        private string all =
            "{\"other\":[{\"image\":\"nginx\",\"name\":\"garbonzia\",\"port\":80},{\"image\":\"ninja\",\"name\":\"rec\",\"port\":8080}],\"staging\":[]}";
        
        [Test]
        public void ParsesRunningContainers_OneRunningContainer_ExpectedNameAndImage()
        {
            var json = "name:fervent_nobel,ports:80/tcp,image:nginx";
             // {"Image":"nginx","Names":"fervent_nobel","Ports":"80/tcp"}
            // name:fervent_nobel,ports:80/tcp,image:nginx

            var result = RunningContainersController.ParsesRunningContainers(json);
            
            result.First().Image.ShouldBe("nginx");
            result.First().Names.ShouldBe("fervent_nobel");
            result.First().Ports.ShouldBe("80/tcp");
        }

        [Test]
        public void ParsesRunningContainers_TwoRunningContainers_ExpectedNameAndImage()
        {
            string json =
                @"name:competent_haibt,ports:80/tcp,image:nginx
                   name:loving_lamarr,ports:0.0.0.0:80->80/tcp,image:ninja";
            List<Container> result = RunningContainersController.ParsesRunningContainers(json);
            
            result.Count.ShouldBe(2);
            result.First().Names.ShouldBe("competent_haibt");
            result.ElementAt(1).Image.ShouldBe("ninja");
        }

        [Test]
        public void ParsesRunningContainers_NoRunningContainers_ExpectedResults()
        {
            string json = String.Empty;
            List<Container> result = RunningContainersController.ParsesRunningContainers(json);
            
            result.ShouldBeNull();
        }

        [Test]
        public void SingleResulter_PortForwarded_GetsOnlyPortNotIP()
        {
            string withIPAndPortString = @"name:loving_lamarr,ports:0.0.0.0:80->80/tcp,image:ninja";

            var result = RunningContainersController.ParsesRunningContainers(withIPAndPortString);
            
            result.First().Ports.ShouldBe("80->80/tcp");
        }

        [Test]
        public void JsonMagick_ListToJson_ExpectedResult()
        {
            // var expectedJson = "{\"Other\":[{\"Image\":\"nginx\",\"Names\":\"garbonzia\",\"Ports\":\"80\"}]}";
            var containersToSend = new List<Container>
            {
                new Container
                {
                    Image = "nginx",
                    Names = "garbonzia",
                    Ports = "80"
                }
            };

            var result = RunningContainersController.JsonMagick(containersToSend);
            string.IsNullOrWhiteSpace(result).ShouldBeFalse();
            result.ShouldContain("garbonzia");
        }
    }
}