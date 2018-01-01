using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiiTrainingProject.IntegrationTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public async Task HomePageShouldReturnContent()
        {
            var webHostBuilder = new WebHostBuilder()
                                //.UseContentRoot(@"C:\Users\pawel\source\repos\SiiTrainingProject\SiiTrainingProject")
                                .UseEnvironment("Test")    //we can set up the environment (development, staging, production...)
                                .UseStartup<Startup>(); //startup class of our web app project

            using (var server = new TestServer(webHostBuilder))
            {
                using (var client = server.CreateClient())
                {
                    var result = await client.GetAsync("/");

                    //fail if non-success result
                    result.EnsureSuccessStatusCode();

                    var responseHtml = await result.Content.ReadAsStringAsync();

                    //assert expected content
                    StringAssert.Contains(responseHtml, "Learn how to build ASP.NET apps that can run anywhere");
                }
            }
        } 
    }
}
