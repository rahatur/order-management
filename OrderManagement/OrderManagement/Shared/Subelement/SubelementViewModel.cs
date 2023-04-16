using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared
{
    public class SubelementViewModel
    {
        public int Id { get; set; }

        public int WindowId { get; set; }
        public string WindowName { get; set; }

        [Display(Name = "Subelement Type")]
        public string Type { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }   
}
