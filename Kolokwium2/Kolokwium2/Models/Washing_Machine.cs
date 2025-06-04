using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Washing_Machine")]
public class Washing_Machine
{
    [Key]
    public int WashingMachineId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public double MaxWeight { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string SerialNumber { get; set; }
    
    public ICollection<Available_Program> AvailablePrograms { get; set; }
}