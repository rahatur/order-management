using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared
{
    public class SubelementAddModel
    {
        [Required]
        public int WindowId { get; set; }

        [Required]
        [Display(Name = "Subelement Type")]
        public string Type { get; set; }

        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
    }
}
