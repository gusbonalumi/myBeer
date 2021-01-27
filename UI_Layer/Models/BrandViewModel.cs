using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Layer.Models
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Brand name")]
        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string BrandName { get; set; }
        [Display(Name = "Country")]
        [Required]
        [MinLength(6)]
        [MaxLength(150)]
        public string BrandNationality { get; set; }
    }
}
