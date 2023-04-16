using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Server.Models
{
    [Table("Window", Schema ="dbo")]
    public class Window
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required] 
        public string Name { get; set; }
        
        [Required] 
        public int Quantity { get; set; }

        
        public virtual Order Order { get; set; }
        public virtual ICollection<Subelement> Subelements { get; }
    }
}
