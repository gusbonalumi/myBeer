using ApplicationCore.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI_Layer.Mappers;
using UI_Layer.Models;

namespace UI_Layer.Controllers.Container
{
    public class ContainerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ContainerController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IActionResult> Index()
        {
            List<ContainerViewModel> containers = new List<ContainerViewModel>();
            try
            {
                var result = await ContainerLogic.GetContainers(_connectionString);
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

        [HttpGet]
        public IActionResult SaveProductContainerForm(int? id)
        {
            ContainerViewModel containerVm = new ContainerViewModel();
            if(id != null)
            {

            }
            return View(containerVm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ContainerViewModel containerViewModel)
        {
            List<ContainerViewModel> containerViewModelList = new List<ContainerViewModel>();
            try
            {
                var productContainer = ProductContainerMapper.FromContainerViewModelToProductContainer(containerViewModel);
                ContainerLogic.SaveNewContainer(_connectionString, productContainer);
                var containers = await ContainerLogic.GetContainers(_connectionString);
                containers.ForEach(c => {
                    containerViewModelList.Add(ProductContainerMapper.FromProductContainerToContainerViewModel(c));
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return View("Index", containerViewModelList);
        }

    }
}
