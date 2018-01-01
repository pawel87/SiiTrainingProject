using Microsoft.AspNetCore.Mvc;
using SiiTrainingProject.Models.Components;

namespace SiiTrainingProject.Components
{
    public class ProductSummaryWithArgument : ViewComponent
    {
        public IViewComponentResult Invoke(string manufacturer)
        {
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
