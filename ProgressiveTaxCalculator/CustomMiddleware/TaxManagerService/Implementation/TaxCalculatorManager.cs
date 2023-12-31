﻿using Microsoft.Extensions.Options;
using ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Interface;
using ProgressiveTaxCalculator.Model.Constants;
using ProgressiveTaxCalculator.Model.Entities;
using ProgressiveTaxCalculator.Model.Objects;
using ProgressiveTaxCalculator.Models;
using ProgressiveTaxCalculator.Sandbox.ApiTools.Client.Interface;
using ProgressiveTaxCalculator.Sandbox.Generics.Interface;
using ProgressiveTaxCalculator.Settings;
using RestSharp;

namespace ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Implementation
{
    public class TaxCalculatorManager : ITaxCalculatorManager
    {
        private readonly ILogger<PostalCodeManager> _logger;
        private readonly IClientOrchestratorAgent _clientOrchestratorAgent;
        private readonly IApplicationGenerics _applicationGenerics;
        private readonly AppSettings _appSettings;

        public TaxCalculatorManager(ILogger<PostalCodeManager> logger, IClientOrchestratorAgent clientOrchestratorAgent, IApplicationGenerics applicationGenerics, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _clientOrchestratorAgent = clientOrchestratorAgent;
            _applicationGenerics = applicationGenerics;
            _appSettings = appSettings.Value;
        }

        public async Task<Tuple<string,bool>> CalculateTaxAsync(ProgressiveTaxViewModel progressiveTaxViewModel) 
        {
            var message = new Tuple<string, bool>(string.Empty,false);
            try
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(CalculateTaxAsync)} about to calculate tax for postal code ID is {progressiveTaxViewModel.PostalCodeId} and an amount of {progressiveTaxViewModel.GrossAmount:n}. "));

                var taxSalaryRequest = new TaxSalaryRequest(progressiveTaxViewModel.PostalCodeId, progressiveTaxViewModel.GrossAmount);

                var taxCalculator = await _clientOrchestratorAgent.SendRequestAsync(_appSettings.ApiBaseUrl ?? "", Endpoints.CalculateIncomeTax, Method.Post, taxSalaryRequest, null, null);

                if (taxCalculator != null)
                {
                    if (taxCalculator.Status == System.Net.HttpStatusCode.OK)
                    {
                        CalculatedTaxApiResponse calculatedTaxApiResponse = _applicationGenerics.Deserialize<CalculatedTaxApiResponse>(_applicationGenerics.Serialize(taxCalculator?.ResponsePayload));
                        if(calculatedTaxApiResponse != null) 
                        {
                            var perc = !string.IsNullOrEmpty(calculatedTaxApiResponse.taxType) && calculatedTaxApiResponse.taxType.Equals("Flat Value") && calculatedTaxApiResponse.grossAmount >= 200000 ? $" value of {calculatedTaxApiResponse.taxAmount}" : $"percentage of {Math.Round(((calculatedTaxApiResponse.taxPercentage ?? 0) * 100),1, MidpointRounding.AwayFromZero)}%";

                            var msg = string.Format(Notifications.CalculatedTax, calculatedTaxApiResponse.postalCode, string.Format("{0:C}", calculatedTaxApiResponse.grossAmount), calculatedTaxApiResponse.taxType, perc, string.Format("{0:C}", calculatedTaxApiResponse.taxAmount), string.Format("{0:C}", calculatedTaxApiResponse.nettAmount));
                            _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, msg));
                            message = new Tuple<string, bool>(msg, true);                  
                        }
                    }
                    else 
                    {
                        message = new Tuple<string, bool>(_applicationGenerics.Deserialize<string>(_applicationGenerics.Serialize(taxCalculator?.ResponsePayload)), false);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(CalculateTaxAsync)} - {ex.Message}"));
                
                message = new Tuple<string, bool>(ex.Message, false);

            }
            return message;
        }
    }
}
