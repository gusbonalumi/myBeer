using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ContainerId { get; set; }
        public ProductContainer Container { get; set; }
        public decimal Price { get; set; }
    }
}
