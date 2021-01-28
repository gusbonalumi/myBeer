using ApplicationCore.Logic;
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
    public class BrandController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BrandController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IActionResult> Index()
        {
            List<BrandViewModel> brands = new List<BrandViewModel>();

            try
            {
                var result = await BrandsLogic.GetAllBrands(_connectionString);
                foreach (var item in result)
                {
                    brands.Add(new BrandViewModel() { 
                        Id = item.Id,
                        BrandName = item.BrandName,
                        BrandNationality = item.Nationality
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return View(brands);
        }

        [HttpGet]
        public IActionResult SaveBrandForm(int? id)
        {
            BrandViewModel brand = new BrandViewModel();

            if (id != null)
            {
                /*Complete later for brand edition options*/
            }

            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Save(BrandViewModel brandViewModel)
        {
            List<BrandViewModel> brandsList = new List<BrandViewModel>();
            try
            {
                var brand = BrandsMapper.FromBrandViewModelToBrand(brandViewModel);
                BrandsLogic.SaveNewBrand(_connectionString, brand);
                
                var brands = await BrandsLogic.GetAllBrands(_connectionString);
                brands.ForEach((brandVM) => {
                    brandsList.Add(BrandsMapper.FromBrandToBrandViewModel(brandVM));
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return View("Index", brandsList);
        }
    }
}
