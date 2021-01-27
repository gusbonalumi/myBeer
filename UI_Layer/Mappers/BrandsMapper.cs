using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_Layer.Models;

namespace UI_Layer.Mappers
{
    public static class BrandsMapper
    {
        public static Brand FromBrandViewModelToBrand(BrandViewModel brandViewModel)
        {
            Brand brand = new Brand() {
                Id = brandViewModel.Id,
                BrandName = brandViewModel.BrandName,
                Nationality = brandViewModel.BrandNationality
            };

            return brand;
        }

        public static BrandViewModel FromBrandToBrandViewModel(Brand brand)
        {
            BrandViewModel brandViewModel = new BrandViewModel() { 
                BrandName = brand.BrandName, 
                BrandNationality = brand.Nationality, 
                Id = brand.Id };
            return brandViewModel;
        }
    }
}
