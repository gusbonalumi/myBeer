using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class ProductContainer
    {
        public int Id { get; set; }
        public float CapacityInOz { get; set; }
        public string ContainerType { get; set; }
        public string ContainerName { get; set; }
        public List<Beer> BeerProducts { get; set; }
    }
}
