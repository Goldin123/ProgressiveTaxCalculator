using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgressiveTaxCalculator.Api.Features.GetPostalCodes.Interface;
using ProgressiveTaxCalculator.Model.Entities;
using ProgressiveTaxCalculator.Model.Objects;

namespace ProgressiveTaxCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ILogger<TaxController> _logger;
        private readonly IApiGetPostalCodes _apiGetPostalCodes;
        public TaxController(ILogger<TaxController> logger, IApiGetPostalCodes apiGetPostalCodes) 
        {
            _logger = logger;
            _apiGetPostalCodes = apiGetPostalCodes;
        }

        [HttpGet]
        [Route("GetPostalCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Get()
        {
            try
            {
                List<PostalCode>? postalCodes;
                postalCodes = await _apiGetPostalCodes.GetPostalCodes();
                if (postalCodes?.Count > 0)
                    return Ok(postalCodes);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("{0} - {1}", DateTime.Now, ex.ToString()));
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CalculateIncomeTax")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Post([FromBody] TaxSalaryRequest taxSalaryRequest)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(Post)} - {ex.Message}"));

                return BadRequest(ex.Message);
            }
        }
    }
}
