using ProgressiveTaxCalculator.Model.Objects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Sandbox.Generics.Interface
{
    public interface IApplicationGenerics
    {
        string Serialize(dynamic param);
        T Deserialize<T>(dynamic param);
        Task<ResponseData> ProcessRestCall(string apiUrl, RestRequest restRequest, X509Certificate2? certificate = null);
        dynamic HandleResponse(string message);
    }
}
