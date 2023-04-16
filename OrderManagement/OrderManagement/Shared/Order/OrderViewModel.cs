using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name of the Order")]
        public string Name { get; set; }

        [Display(Name = "Name of the State")]
        public string State { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public ICollection<WindowViewModel> Windows { get; set; }
    }
}
