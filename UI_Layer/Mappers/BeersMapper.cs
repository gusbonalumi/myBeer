using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UI_Layer.Models;

namespace UI_Layer.Mappers
{
    public static class BeersMapper
    {
        public static List<BeerProductViewModel> BeersToBeerProductsViewModel(List<Beer> beers)
        {
            List<BeerProductViewModel> viewModelBeers = new List<BeerProductViewModel>();
            foreach (var beer in beers)
            {
                viewModelBeers.Add(new BeerProductViewModel()
                {
                    Id = beer.Id,
                    BrandName = beer.Brand.BrandName,
                    ContainerName = beer.Container.ContainerName,
                    ContainerType = beer.Container.ContainerType,
                    Price = $"{beer.Price.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}",
                    Size = $"{beer.Container.CapacityInOz} fl. oz."
                });
            }
            return viewModelBeers;
        }

        public static Beer BeerProductViewModelToBeer(BeerProductViewModel viewModelBeer)
        {
            Beer beer = new Beer();
            beer.BrandId = viewModelBeer.BrandId;
            beer.ContainerId = viewModelBeer.ContainerId;
            decimal price;
            beer.Price = decimal.TryParse(viewModelBeer.Price, out price) ? price : 0;
            return beer;
        }
    }
}
