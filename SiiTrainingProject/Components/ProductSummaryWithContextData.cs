using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SiiTrainingProject.Models.Components;

namespace SiiTrainingProject.Components
{
    public class ProductSummaryWithContextData : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            var manufacturer = RouteData.Values["id"] as string;
            //some logic here...

            return View(new ProductSummaryViewModel()
            {
                CategoriesCount = 2,
                ProductsCount = 5,
                Manufacturer = manufacturer
            });
        }
    }
}
