using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Layer.Models
{
    public class BeerProductViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ContainerName { get; set; }
        public string ContainerType { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
    }
}
