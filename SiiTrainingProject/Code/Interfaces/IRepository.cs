using SiiTraining.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiiTrainingProject.Code.Interfaces
{
    public interface IRepository
    {
        List<Product> GetAllProducts();
    }
}
