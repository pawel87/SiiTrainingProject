using SiiTrainingProject.Code.Interfaces;

namespace SiiTrainingProject.Components
{
    public class ProductsSummaryViewComponent
    {
        private readonly IRepository repository;

        public ProductsSummaryViewComponent(IRepository repository)
        {
            this.repository = repository;
        }

        public string Invoke()
        {
            return $"We have {repository.GetAllProducts().Count} products in our store";
        }
    }
}
