﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace SiiTrainingProject.Controllers
{
    public class DocumentationController : Controller
    {
        private readonly IApiDescriptionGroupCollectionProvider _apiExplorer;
        public DocumentationController(IApiDescriptionGroupCollectionProvider apiExplorer)
        {
            _apiExplorer = apiExplorer;
        }

        public IActionResult Index()
        {
            return View(_apiExplorer);
        }
    }
}