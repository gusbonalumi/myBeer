using ApplicationCore.Logic;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UI_Layer.Mappers;
using UI_Layer.Models;

namespace UI_Layer.Controllers
{
    public class BeerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public BeerController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IActionResult> Index()
        {
            List<BeerProductViewModel> viewModelBeers = new List<BeerProductViewModel>();

            try
            {
                var storedBeers = await BeerProductsLogic.GetBeerProducts(_connectionString);
                viewModelBeers = BeersMapper.BeersToBeerProductsViewModel(storedBeers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return View(viewModelBeers);
        }

        [HttpGet]
        public async Task<IActionResult> SaveBeerProductsForm(string beerId)
        {
            BeerProductViewModel beerProductViewModel = new BeerProductViewModel();
            try
            {
                beerProductViewModel.Brands = await BrandsLogic.GetAllBrands(_connectionString);
                beerProductViewModel.ProductContainers = await ContainerLogic.GetContainers(_connectionString);
                if (!string.IsNullOrEmpty(beerId))
                {
                    int parsedId;
                    var intBeerid = Int32.TryParse(beerId, out parsedId) ? parsedId : throw new ArgumentException("Beer Id is probably null or an invalid format");
                    var beer = await BeerProductsLogic.GetBeerById(intBeerid, _connectionString);
                    BeersMapper.SetBeerPropertiesToViewModel(beerProductViewModel, beer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return View(beerProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(BeerProductViewModel beer)
        {
            try
            {
                Beer beerProduct = BeersMapper.BeerProductViewModelToBeer(beer);
                BeerProductsLogic.SaveBeerProduct(beerProduct, _connectionString);
                var storedBeerProducts = await BeerProductsLogic.GetBeerProducts(_connectionString);
                List<BeerProductViewModel> beers = BeersMapper.BeersToBeerProductsViewModel(storedBeerProducts);
                return View("Index", beers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return View("Error");
            }

        }
    }
}
