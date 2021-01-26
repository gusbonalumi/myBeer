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

        public BeerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<BeerProductViewModel> viewModelBeers = new List<BeerProductViewModel>();

            try
            {
                var storedBeers = await BeerProductsLogic.GetBeerProducts(_configuration.GetConnectionString("DefaultConnection"));
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
            BeerProductViewModel beerProducts = new BeerProductViewModel();
            try
            {
                if (beerId is null)
                {
                    beerProducts.Brands = BrandsLogic.GetAllBrands(_configuration.GetConnectionString("DefaultConnection"));
                    beerProducts.ProductContainers = ContainerLogic.GetContainers(_configuration.GetConnectionString("DefaultConnection"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return View(beerProducts);
        }

        [HttpPost]
        public async Task<IActionResult> Save(BeerProductViewModel beer)
        {
            try
            {
                Beer beerProduct = BeersMapper.BeerProductViewModelToBeer(beer);
                BeerProductsLogic.SaveBeerProduct(beerProduct, _configuration.GetConnectionString("DefaultConnection"));
                var storedBeerProducts = await BeerProductsLogic.GetBeerProducts(_configuration.GetConnectionString("DefaultConnection"));
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
