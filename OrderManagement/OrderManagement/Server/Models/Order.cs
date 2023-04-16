using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Server.Models
{
    [Table("Order", Schema ="dbo")]
    public class Order
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required] 
        public string Name { get; set; }
        
        [Required] 
        public string State { get; set; }

        public virtual ICollection<Window> Windows { get; set; }
    }
}
