using NUnit.Framework;
using ReactDotnet.Controllers;

namespace TestProject1
{
    public class StuffControllerTests
    {
        [Test]
        
        public void Initial()
        {
            var json = "name:fervent_nobel,ports:80/tcp,image:nginx";

//            name:fervent_nobel,ports:80/tcp,image:nginx

            var somethingPretty = StuffController.Resulter(json);
            Assert.NotNull(somethingPretty);
        }

        [Test]
        public void TestGet()
        {
            StuffController controller = new StuffController();
            var result = controller.Get();
        }
    }
}