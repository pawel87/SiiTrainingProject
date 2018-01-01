using System.Collections.Generic;

namespace SiiTrainingProject.Code.Interfaces
{
    public interface IFilterDiagnostics
    {
        IEnumerable<string> Messages { get; }
        void AddMessage(string message);
    }
}
