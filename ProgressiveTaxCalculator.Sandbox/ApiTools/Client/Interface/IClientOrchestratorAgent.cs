using ProgressiveTaxCalculator.Model.Objects;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Sandbox.ApiTools.Client.Interface
{
    public interface IClientOrchestratorAgent
    {
        Task<ResponseData> SendRequestAsync(string apiUrl, string path, Method methodType, object? payload = null, X509Certificate2? certificate = null, IDictionary<string, string>? extraHeaders = null);
    }
}
