using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared
{
    public class OrderAddModel
    {
        [Required]
        [Display(Name = "Name of the Order")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Name of the State")]
        public string State { get; set; }
    }
}
