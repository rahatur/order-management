using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared
{
    public class WindowViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Order Id")]
        public int OrderId { get; set; }
        
        [Display(Name = "Order Id")]
        public string OrderNAme { get; set; }

        [Display(Name = "Name of the Order")]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }   
}
