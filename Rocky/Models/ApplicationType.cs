using System.ComponentModel.DataAnnotations;
using Rocky.Data;

namespace Rocky.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }
        
        [Required]

        public string Name { get; set; }
        
    }
}