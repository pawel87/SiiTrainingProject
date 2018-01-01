using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.TestHost;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;

namespace SiiTrainingProject.IntegrationTests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async Task TestValuesApi()
        {
            var webHostBuilder = new WebHostBuilder()
                                .UseEnvironment("Test")    //we can set up the environment (development, staging, production...)
                                .UseStartup<Startup>(); //startup class of our web app project

            using(var server = new TestServer(webHostBuilder))
            {
                using(var client = server.CreateClient())
                {
                    var result = await client.GetStringAsync("/dummyapi/values/getsample");
                    Assert.AreEqual("[\"Hello\",\"World\"]", result);
                }
            }
        }

        [TestMethod]
        public async Task TestPutShouldReturnBadRequestWhenValueNotGiven()
        {
            var webHostBuilder = new WebHostBuilder()
                                .UseEnvironment("Test")    //we can set up the environment (development, staging, production...)
                                .UseStartup<Startup>(); //startup class of our web app project

            using (var server = new TestServer(webHostBuilder))
            {
                using (var client = server.CreateClient())
                {
                    var content = new StringContent("");

                    var result = await client.PutAsync("/dummyapi/values/putsample", content);

                    
                    Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
                }
            }
        }
    }
}
