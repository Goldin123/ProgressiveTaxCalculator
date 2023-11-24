using Microsoft.AspNetCore.Mvc;
using ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Interface;
using ProgressiveTaxCalculator.Models;
using System.Diagnostics;
using System.Reflection;

namespace ProgressiveTaxCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostalCodeManager _postalCodeManager;

        public HomeController(ILogger<HomeController> logger, IPostalCodeManager postalCodeManager)
        {
            _logger = logger;
            _postalCodeManager = postalCodeManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ProgressiveTaxViewModel();
            try
            {
                model.PostalCodes = await _postalCodeManager.GetPostalCodesAsync();

            } catch (Exception ex)
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(Index)} - {ex.Message}"));

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProgressiveTaxViewModel progressiveTaxViewModel)
        {
            try
            {
                if (progressiveTaxViewModel.PostalCodes == null)
                    progressiveTaxViewModel.PostalCodes = await _postalCodeManager.GetPostalCodesAsync();

                if (ModelState.IsValid)
                {
                    return View(progressiveTaxViewModel);
                }
            }
            catch (Exception ex) 
            {
                _logger.LogCritical(string.Format("{0} - {1}", DateTime.Now, $"{nameof(Index)} - {ex.Message}"));
            }
            return View(progressiveTaxViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}