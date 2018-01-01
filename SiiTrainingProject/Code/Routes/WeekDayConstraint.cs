using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace SiiTrainingProject.Code.Routes
{
    public class WeekDayConstraint : IRouteConstraint
    {
        private static string[] days = new[] { "mon", "tue", "wed", "thu", "fri" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var isMatch = days.Contains(values[routeKey]?.ToString().ToLowerInvariant());
            return isMatch;
        }
    }
}
