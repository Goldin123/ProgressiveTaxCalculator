﻿using ProgressiveTaxCalculator.Api.Controllers;
using ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Interface;
using ProgressiveTaxCalculator.InMemory.Database.Repository.Interface;
using ProgressiveTaxCalculator.Model.Entities;
using ProgressiveTaxCalculator.Model.Objects;

namespace ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Implementation
{
    public class ApiGetPostalCodes : IApiGetPostalCodes
    {
        private readonly ILogger<ApiGetPostalCodes> _logger;
        private readonly IProgressiveTaxCalculatorInMemoryRepository _inMemoryTaxRepository;

        public ApiGetPostalCodes(ILogger<ApiGetPostalCodes> logger, IProgressiveTaxCalculatorInMemoryRepository inMemoryTaxRepository) 
        {
            _logger = logger;
            _inMemoryTaxRepository = inMemoryTaxRepository;
        }

        public async Task<List<PostalCodeResponse>> GetPostalCodes() 
        {
            try 
            {
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(GetPostalCodes)} sending request to get postal codes."));

                return await _inMemoryTaxRepository.GetPostalCodesAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(GetPostalCodes)} - {ex.Message}"));

                throw new Exception(ex.Message);
            }
        }

    }
}
