using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Model.Constants
{
    public static class Notifications
    {
        public const string InternalErrorOccurred = "An Internal Server Error Occurred";
        public const string CalculatedTax = "Based on the postal code {0}, for an annual amount of {1}, the tax calculation used is {2}, which uses a {3}, the total tax amount is {4} and total nett amount is {5}.";
    }
}
