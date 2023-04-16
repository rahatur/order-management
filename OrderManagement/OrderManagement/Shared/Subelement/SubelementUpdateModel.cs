using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Shared
{
    public class SubelementUpdateModel : SubelementAddModel
    {
        [Required]
        public int Id { get; set; }
    }
}
