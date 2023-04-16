using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Server.Models
{
    [Table("Subelement", Schema ="dbo")]
    public class Subelement
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int WindowId { get; set; }

        [Required] 
        public string Type { get; set; }
        
        [Required] 
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        
        public virtual Window Window { get; set; }
    }
}
