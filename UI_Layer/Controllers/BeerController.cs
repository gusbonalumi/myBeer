using ApplicationCore.Logic;
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
                BeerProductsLogic beerL = new BeerProductsLogic(_configuration.GetConnectionString("DefaultConnection"));
                var StoredBeersList = await beerL.GetBeerProducts();
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
    }
}
