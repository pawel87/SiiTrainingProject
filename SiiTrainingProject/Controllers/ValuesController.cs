using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SiiTrainingProject.Controllers
{
    [Route("dummyapi/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        [Route("getsample")]
        public IEnumerable<string> Get()
        {
            return new[] { "Hello", "World" };
        }

        [HttpPut]
        [Route("putsample")]
        public IActionResult Put(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new BadRequestResult();
            }

            return Ok();
        }
    }
}