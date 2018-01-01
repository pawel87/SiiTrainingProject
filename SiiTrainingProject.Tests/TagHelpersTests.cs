using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiiTrainingProject.Code.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiiTrainingProject.Tests
{
    [TestClass]
    public class TagHelpersTests
    {
        [TestMethod]
        public void TestButtonTagHelper()
        {
            //arrange
            var context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), "uniqueid");
            var output = new TagHelperOutput("button", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

            //act
            var helper = new ButtonTagHelper
            {
                BsButtonColor = "valueToBeTested"
            };

            helper.Process(context, output);

            //assert
            Assert.AreEqual($"btn btn-{helper.BsButtonColor}", output.Attributes["class"].Value);
        }
    }
}
