using System;
using Microsoft.AspNetCore.Mvc;
using SiiTrainingProject.Code.Interfaces;
using SiiTrainingProject.Models;

namespace SiiTrainingProject.Controllers
{
    public class TestController : Controller
    {
        private readonly IRepository repository;

        public TestController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult GetAllProducts()
        {
            var products = repository.GetAllProducts();

            return View(products);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                //add new entity into storage...
            }

            return RedirectToAction(actionName: nameof(GetAllProducts));
        }

        public ViewResult DateTimeAction()
        {
            var vm = DateTime.Now;
            return View(vm);
        }

        public ViewResult HelloWorldAction()
        {
            var vm = "Hello World";
            return View(vm);
        }

        public RedirectResult Redirect()
        {
            return RedirectPermanent("/Example/Index");
        }

        public RedirectToRouteResult RedirectRoute()
        {
            return RedirectToRoute(new { controller = "Example", action = "Index", id = "sampleId" });
        }

        public JsonResult JsonAction()
        {
            return Json(new[] { "Sii", "Power", "People" });
        }

        public StatusCodeResult PageNotFound()
        {
            return NotFound();
        }
    }
}