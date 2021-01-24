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
    public class BrandController : Controller
    {
        private readonly IConfiguration _configuration;

        public BrandController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<BrandViewModel> brands = new List<BrandViewModel>();

            try
            {
                var result = BrandsLogic.GetAllBrands(_configuration.GetConnectionString("DefaultConnection"));
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
    }
}
