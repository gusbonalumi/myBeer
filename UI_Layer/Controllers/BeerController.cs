using ApplicationCore.Logic;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        public IActionResult SaveBeerProductsForm(int? beerId)
        {
            BeerProductViewModel beerProduct = new BeerProductViewModel();
            try
            {
                beerProduct.Brands = BrandsLogic.GetAllBrands(_connectionString);
                beerProduct.ProductContainers = ContainerLogic.GetContainers(_connectionString);
                if (beerId != null)
                {
                    var beer = BeerProductsLogic.GetBeerById((int)beerId, _connectionString);
                    beerProduct.Id = beer.Id;
                    beerProduct.ContainerId = beer.ContainerId;
                    beerProduct.BrandId = beer.BrandId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return View(beerProduct);
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
