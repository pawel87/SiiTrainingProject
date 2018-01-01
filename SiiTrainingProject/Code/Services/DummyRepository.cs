using SiiTraining.Domain;
using SiiTrainingProject.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTrainingProject.Code.Services
{
    public class DummyRepository : IRepository
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product>()
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
                new Product()
                {
                    Id = 3,
                    Name = "PowerBank",
                    CategoryId = 2,
                    Price = 99,
                    IsPromotion = false
                }
            };

            throw new NotImplementedException();
        }
    }
}
