using ApplicationCore.Logic;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            List<BeerProductViewModel> beers = new List<BeerProductViewModel>();

            try
            {
                var StoredBeersList = await BeerProductsLogic.GetBeerProducts(_configuration.GetConnectionString("DefaultConnection"));
                foreach (var beer in StoredBeersList)
                {
                    beers.Add(new BeerProductViewModel()
                    {
                        BrandName = beer.Brand.BrandName,
                        ContainerName = beer.Container.ContainerName,
                        ContainerType = beer.Container.ContainerType,
                        Price = $"${beer.Price.ToString()}",
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
        public IActionResult Save(BeerProductViewModel beer)
        {
            try
            {
                Beer beerProduct = new Beer();
                beerProduct.BrandId = beer.BrandId;
                beerProduct.ContainerId = beer.ContainerId;
                decimal price;
                beerProduct.Price = decimal.TryParse(beer.Price, out price) ? price : 0;
                BeerProductsLogic.SaveBeerProduct(beerProduct, _configuration.GetConnectionString("DefaultConnection"));
                return View("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return View("Error");
            }

        }
    }
}
