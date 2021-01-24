using ApplicationCore.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using UI_Layer.Models;

namespace UI_Layer.Controllers.Container
{
    public class ContainerController : Controller
    {
        private readonly IConfiguration _configuration;

        public ContainerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<ContainerViewModel> containers = new List<ContainerViewModel>();
            try
            {
                var result = ContainerLogic.GetContainers(_configuration.GetConnectionString("DefaultConnection"));
                foreach (var item in result)
                {
                    containers.Add(new ContainerViewModel(){ 
                        Id = item.Id,
                        ContainerName = item.ContainerName,
                        ContainerType = item.ContainerType,
                        CapacityInOz = item.CapacityInOz.ToString("00.00")
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return View(containers);
        }

    }
}
