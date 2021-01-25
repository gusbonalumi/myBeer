using ApplicationCore.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using UI_Layer.Models;
using System.Threading.Tasks;
using System.Globalization;

namespace UI_Layer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<BeerProductViewModel> beers = new List<BeerProductViewModel>();
            try
            {
                var result = await BeerProductsLogic.GetThreeRandomBeerProducts(_configuration.GetConnectionString("DefaultConnection"));
                foreach (var beer in result)
                {
                    beers.Add(new BeerProductViewModel() { 
                        Id = beer.Id,
                        BrandName = beer.Brand.BrandName,
                        ContainerName = beer.Container.ContainerName,
                        ContainerType = beer.Container.ContainerType,
                        Price = beer.Price.ToString("C",CultureInfo.CreateSpecificCulture("en-US")),
                        Size = $"{beer.Container.CapacityInOz} fl. oz."
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            
            return View(beers);
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
