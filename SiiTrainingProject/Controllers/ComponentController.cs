using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiiTrainingProject.Code.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SiiTrainingProject.Controllers
{
    [ViewComponent(Name = "ControllerComponent")]
    public class ComponentController : Controller
    {
        private readonly IRepository repository;

        public ComponentController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IViewComponentResult Invoke()
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<IEnumerable<string>>(ViewData, repository.GetAllProducts().Take(2))
            };
        }
    }
}