using Microsoft.Extensions.Logging;
using ProgressiveTaxCalculator.Model.Constants;
using ProgressiveTaxCalculator.Model.Objects;
using ProgressiveTaxCalculator.Sandbox.ApiTools.Client.Interface;
using ProgressiveTaxCalculator.Sandbox.Generics.Interface;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgressiveTaxCalculator.Sandbox.ApiTools.Client.Implementation
{
    public class ClientOrchestratorAgent : IClientOrchestratorAgent
    {
        private readonly ILogger<ClientOrchestratorAgent> _logger;
        private readonly IApplicationGenerics _applicationGenerics;

        public ClientOrchestratorAgent(ILogger<ClientOrchestratorAgent> logger, IApplicationGenerics applicationGenerics) 
        {
            _logger = logger;
            _applicationGenerics = applicationGenerics;
        }

        /// <summary>
        /// This method will handle all rest calls to api's
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="payload"></param>
        /// <param name="certificate"></param>
        /// <param name="extraHeaders">All extra headers like bearer token etc</param>
        /// <returns></returns>
        public async Task<ResponseData> SendRequestAsync(string apiUrl, string path, Method methodType, object? payload = null, X509Certificate2? certificate = null, IDictionary<string, string>? extraHeaders = null)
        {
            var responseData = new ResponseData();
            try
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SendRequestAsync)} about to send request."));

                var restRequest = new RestRequest(path, methodType);

                restRequest.AddHeader("Accept", ContentNegotiationTypes.Json);
                restRequest.AddHeader("Content-Type", ContentNegotiationTypes.Json);

                if (extraHeaders is not null)
                {
                    foreach (var header in extraHeaders)
                    {
                        restRequest.AddHeader(header.Key, header.Value);
                    }
                }
                if (payload != null)
                {

                    var jsonPayload = _applicationGenerics.Serialize(payload);
                    restRequest.AddBody(jsonPayload, ContentNegotiationTypes.Json);

                    _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(SendRequestAsync)} sending request to endpoint:-> {apiUrl} : request :-> {jsonPayload}. "));

                }
                responseData = await _applicationGenerics.ProcessRestCall(apiUrl, restRequest, certificate);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(SendRequestAsync)} - {ex.Message}"));

                responseData = new() { ResponsePayload = _applicationGenerics.HandleResponse(Notifications.InternalErrorOccurred), Status = HttpStatusCode.InternalServerError };
            }
            finally
            {
                _logger.LogInformation($"System {nameof(SendRequestAsync)} response status: {responseData.Status}");
            }
            return responseData;
        }

    }
}
