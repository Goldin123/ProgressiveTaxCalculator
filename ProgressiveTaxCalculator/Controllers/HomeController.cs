using Microsoft.AspNetCore.Mvc;
using ProgressiveTaxCalculator.CustomMiddleware.TaxManagerService.Interface;
using ProgressiveTaxCalculator.Model.Constants;
using ProgressiveTaxCalculator.Models;
using System.Diagnostics;
using System.Reflection;

namespace ProgressiveTaxCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostalCodeManager _postalCodeManager;
        private readonly ITaxCalculatorManager _taxCalculatorManager;

        public HomeController(ILogger<HomeController> logger, IPostalCodeManager postalCodeManager, ITaxCalculatorManager taxCalculatorManager)
        {
            _logger = logger;
            _postalCodeManager = postalCodeManager;
            _taxCalculatorManager = taxCalculatorManager;
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
                _logger.LogInformation(string.Format("{0} - {1}", DateTime.Now, $"System {nameof(Index)} post home page values."));

                if (progressiveTaxViewModel.PostalCodes == null)
                    progressiveTaxViewModel.PostalCodes = await _postalCodeManager.GetPostalCodesAsync();

                if (ModelState.IsValid)
                {
                    var calculation = await _taxCalculatorManager.CalculateTaxAsync(progressiveTaxViewModel);

                    if (calculation != null) 
                    {
                        if (calculation.Item2)
                            ViewBag.ResultMessage =  calculation.Item1;
                        else 
                        {
                            var err = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier , Message = calculation.Item1};
                            return RedirectToAction("Error",err);
                        }

                    }

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
        public IActionResult Error(ErrorViewModel errorViewModel )
        {
            return View(errorViewModel);
        }
    }
}