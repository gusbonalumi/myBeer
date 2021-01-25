using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Layer.Models
{
    public class BeerProductViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }
        [Display(Name ="Container Name")]
        public string ContainerName { get; set; }
        [Display(Name = "Container Type")]
        public string ContainerType { get; set; }
        [Required]
        public string Price { get; set; }
        public string Size { get; set; }
        [Display(Name ="Brand")]
        [Required]
        public int BrandId { get; set; }
        [Display(Name = "Container")]
        [Required]
        public int ContainerId { get; set; }
        /*Comboboxes*/
        public List<Brand> Brands { get; set; }
        [Display(Name ="Containers")]
        public List<ProductContainer> ProductContainers { get; set; }
    }
}
