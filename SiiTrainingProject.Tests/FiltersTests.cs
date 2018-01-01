using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiiTrainingProject.Code.Filters;
using System.Linq;

namespace SiiTrainingProject.Tests
{
    [TestClass]
    public class FiltersTests
    {
        [TestMethod]
        public void TestHttpsFilter()
        {
            //arrange
            var httpRequest = new Mock<HttpRequest>();
            httpRequest.SetupSequence(m => m.IsHttps).Returns(true)
                                                     .Returns(false);

            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(m => m.Request).Returns(httpRequest.Object);

            var actionContext = new ActionContext(httpContext.Object, new RouteData(), new ActionDescriptor());
            var authorizationContext = new AuthorizationFilterContext(actionContext, Enumerable.Empty<IFilterMetadata>().ToList());

            var filter = new HttpsOnlyAttribute();

            //act & assert
            filter.OnAuthorization(authorizationContext);
            Assert.IsNull(authorizationContext.Result);

            filter.OnAuthorization(authorizationContext);
            Assert.IsInstanceOfType(authorizationContext.Result, typeof(StatusCodeResult));
            Assert.AreEqual(StatusCodes.Status403Forbidden, (authorizationContext.Result as StatusCodeResult).StatusCode);


        }


    }
}
