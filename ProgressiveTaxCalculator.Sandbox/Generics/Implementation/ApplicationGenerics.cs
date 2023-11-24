using Microsoft.Extensions.Logging;
using ProgressiveTaxCalculator.Model.Objects;
using ProgressiveTaxCalculator.Sandbox.Generics.Interface;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Sandbox.Generics.Implementation
{
    public class ApplicationGenerics : IApplicationGenerics
    {
        private readonly ILogger<ApplicationGenerics> _logger;

        public ApplicationGenerics (ILogger<ApplicationGenerics> logger) 
        {
            _logger = logger;
        }

        public string Serialize(dynamic param) => JsonSerializer.Serialize(param);
        public T Deserialize<T>(dynamic param) => JsonSerializer.Deserialize<T>(param);
        public async Task<ResponseData> ProcessRestCall(string apiUrl, RestRequest restRequest, X509Certificate2? certificate = null)
        {
            var restClient = certificate == null ? new(apiUrl) : new RestClient(new RestClientOptions
            {
                ClientCertificates = new() { certificate },
                BaseUrl = new(apiUrl)
            });

            var response = await restClient.ExecuteAsync<ResponseData>(restRequest);

            return new() { Status = response.StatusCode, ResponsePayload = Deserialize<dynamic>(response.Content ?? string.Empty) };
        }
        public dynamic HandleResponse(string message) => Deserialize<dynamic>(CreateResponse(message));
        private string CreateResponse(string message) => Serialize(new { message });

    }
}
