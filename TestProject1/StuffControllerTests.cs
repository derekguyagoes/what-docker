using NUnit;
using NUnit.Framework;

namespace ReactDotnet.Controllers
{
    public class StuffControllerTests
    {
        [Test]
        public void Initial()
        {
            var psString = $"CONTAINER ID        IMAGE               STATUS              NAMES" +
                           "21ab0afd3afd        nginx               Up 38 seconds       fervent_nobel";


            var json = "{\"Names\":\"fervent_nobel\",\"Ports\":\"80/tcp\",\"Image\":\"nginx\"}";

          
            
            var somethingPretty = StuffController.Resulter(json);
            Assert.NotNull(somethingPretty);
            
        }
    }
}