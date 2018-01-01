using Microsoft.AspNetCore.Mvc;
using SiiTrainingProject.Code.Interfaces;
using SiiTrainingProject.Models.Components;

namespace SiiTrainingProject.Components
{
    public class ProductSummary : ViewComponent
    {
        private readonly IRepository repository;

        public ProductSummary(IRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(new ProductSummaryViewModel()
            {
                ProductsCount = repository.GetAllProducts().Count,
                CategoriesCount = 5
            });
        }
    }
}
