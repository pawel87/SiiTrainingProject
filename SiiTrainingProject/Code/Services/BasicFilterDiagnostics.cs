using SiiTrainingProject.Code.Interfaces;
using System.Collections.Generic;

namespace SiiTrainingProject.Code.Services
{
    public class BasicFilterDiagnostics : IFilterDiagnostics
    {
        private List<string> messages = new List<string>();

        public IEnumerable<string> Messages => messages;

        public void AddMessage(string message)
        {
            messages.Add(message);
        }
    }
}
