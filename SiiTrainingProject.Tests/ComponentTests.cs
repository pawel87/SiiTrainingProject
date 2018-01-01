using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiiTraining.Domain;
using SiiTrainingProject.Code.Interfaces;
using SiiTrainingProject.Components;
using SiiTrainingProject.Models.Components;
using System.Collections.Generic;

namespace SiiTrainingProject.Tests
{
    [TestClass]
    public class ComponentTests
    {
        [TestMethod]
        public void CallingComponentShouldResultWithValidModelValues()
        {
            //arrange
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.GetAllProducts()).Returns(new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "iPhone 5",
                    CategoryId = 1,
                    Price = 1999,
                    IsPromotion = false
                },
                new Product()
                {
                    Id = 2,
                    Name = "Samsung S8",
                    CategoryId = 1,
                    Price = 2399,
                    IsPromotion = true
                },
            });

            var viewCompoment = new ProductSummary(repositoryMock.Object);

            //act
            var result = viewCompoment.Invoke() as ViewViewComponentResult;

            //assert
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(ProductSummaryViewModel));
            Assert.AreEqual(2, ((ProductSummaryViewModel)result.ViewData.Model).ProductsCount);
        }
    }
}
