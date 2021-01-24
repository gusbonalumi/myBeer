using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Layer.Models
{
    public class ContainerViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Name")]
        public string ContainerName { get; set; }
        [Display(Name = "Type")]
        public string ContainerType { get; set; }
        [Display(Name ="Size")]
        public string CapacityInOz { get; set; }
    }
}
