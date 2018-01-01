using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiiTraining.Domain;
using SiiTrainingProject.Code.Interfaces;
using SiiTrainingProject.Controllers;
using SiiTrainingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiiTrainingProject.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void GetAllProductsShouldReturnViewResultWithListOfAllProducts()
        {
            //arrange
            var controller = GetController();

            //act 
            var result = controller.GetAllProducts();

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType((result as ViewResult).ViewData.Model, typeof(List<Product>));
            var model = (result as ViewResult).ViewData.Model as List<Product>;
            Assert.AreEqual(2, model.Count);
        }

        [TestMethod]
        public void AddProductReturnBadRequestWhenModelStateIsNotValid()
        {
            //arrange
            var controller = GetController();
            controller.ModelState.AddModelError("Name", "Name is required");
            var model = new AddProductViewModel();

            //act
            var result = controller.AddProduct(model);

            //assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType((result as BadRequestObjectResult).Value, typeof(SerializableError));
        }


        [TestMethod]
        public void TypePassedToViewIsDateTime()
        {
            //arrange
            var controller = GetController();

            //act
            var result = controller.DateTimeAction();

            //assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(DateTime));
        }

        [TestMethod]
        public void ActionShouldDoRedirectPermanent()
        {
            //arrange
            var controller = GetController();

            //act
            var result = controller.Redirect();

            //assert
            Assert.AreEqual("/Example/Index", result.Url);
            Assert.IsTrue(result.Permanent);
        }

        [TestMethod]
        public void ActionShouldDoRoutedRedirection()
        {
            //arrange
            var controller = GetController();

            //act
            var result = controller.RedirectRoute();

            //assert
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("sampleId", result.RouteValues["id"]);
        }

        [TestMethod]
        public void JsonActionShouldReturnGivenArray()
        {
            //arrange
            var controller = GetController();

            //act
            var result = controller.JsonAction();

            //arrange
            Assert.AreEqual(new [] { "Sii", "Power", "People" }, result.Value);
        }

        [TestMethod]
        public void NotFoundPageShouldReturn404StatusCode()
        {
            //arrange
            var controller = GetController();

            //act
            var result = controller.PageNotFound();

            //assert
            Assert.AreEqual(404, result.StatusCode);
        }

        private TestController GetController()
        {
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.GetAllProducts()).Returns(GetSampleProducts());
            var controller = new TestController(repositoryMock.Object);
            return controller;
        }

        private List<Product> GetSampleProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "A"
                },
                new Product()
                {
                    Id = 2,
                    Name = "B"
                }
            };
        }

    }
}
