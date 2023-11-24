using Microsoft.Extensions.Options;
using ProgressiveTaxCalculator.Controllers;
using ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Interface;
using ProgressiveTaxCalculator.Model.Constants;
using ProgressiveTaxCalculator.Model.Entities;
using ProgressiveTaxCalculator.Model.Objects;
using ProgressiveTaxCalculator.Sandbox.ApiTools.Client.Interface;
using ProgressiveTaxCalculator.Sandbox.Generics.Interface;
using ProgressiveTaxCalculator.Settings;
using RestSharp;
using System.Text.Json.Serialization;

namespace ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Implementation
{
    public class PostalCodeManager : IPostalCodeManager
    {
        private readonly ILogger<PostalCodeManager> _logger;
        private readonly IClientOrchestratorAgent _clientOrchestratorAgent;
        private readonly IApplicationGenerics _applicationGenerics;
        private readonly AppSettings _appSettings;
        public PostalCodeManager(ILogger<PostalCodeManager> logger, IClientOrchestratorAgent clientOrchestratorAgent, IOptions<AppSettings> appSettings, IApplicationGenerics applicationGenerics)
        {
            _logger = logger;
            _clientOrchestratorAgent = clientOrchestratorAgent;
            _appSettings = appSettings.Value;
            _applicationGenerics = applicationGenerics;
        }

        public async Task<List<PostalCodeResponse>> GetPostalCodesAsync()
        {
            var postalCodes = new List<PostalCodeResponse>();
            try
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(GetPostalCodesAsync)} loading available postal codes. "));

                var apiPostalCodes = await _clientOrchestratorAgent.SendRequestAsync(_appSettings.ApiBaseUrl ?? "", Endpoints.GetPostalCodes, Method.Get, null, null, null);

                if (apiPostalCodes != null)
                {
                    if (apiPostalCodes.Status == System.Net.HttpStatusCode.OK)
                        postalCodes = _applicationGenerics.Deserialize<List<PostalCodeResponse>>(_applicationGenerics.Serialize(apiPostalCodes?.ResponsePayload));
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(GetPostalCodesAsync)} - {ex.Message}"));
            }

            return postalCodes;
        }
    }
}
