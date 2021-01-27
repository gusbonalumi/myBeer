using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_Layer.Models;

namespace UI_Layer.Mappers
{
    public static class ProductContainerMapper
    {
        public static ContainerViewModel FromProductContainerToContainerViewModel(ProductContainer container)
        {
            var containerViewModel = new ContainerViewModel() {
                Id = container.Id,
                ContainerName = container.ContainerName,
                ContainerType = container.ContainerType,
                CapacityInOz = container.CapacityInOz.ToString("00.00")
            };
            return containerViewModel;
        }

        public static ProductContainer FromContainerViewModelToProductContainer(ContainerViewModel containerViewModel)
        {
            float size;
            var productContainer = new ProductContainer()
            {
                Id = containerViewModel.Id,
                ContainerName = containerViewModel.ContainerName,
                ContainerType = containerViewModel.ContainerType,
                CapacityInOz = float.TryParse(containerViewModel.CapacityInOz, out size) ? size : 0
            };
            return productContainer;
        }
    }
}
