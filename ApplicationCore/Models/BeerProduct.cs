using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class BeerProduct
    {
        public string BrandName { get; set; }
        public string ContainerName { get; set; }
        public string ContainerType { get; set; }
        public string Price { get; set; }
        private float capacityInOz;
        public string CapacityInOz
        {
            get { return $"{capacityInOz.ToString()} fl. oz."; }
            set {
                float number;
                if(float.TryParse(value, out number))
                {
                    this.capacityInOz = number;
                } else { this.capacityInOz = 0; }
            }
        }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ContainerId { get; set; }
        public ProductContainer Container { get; set; }
    }
}
