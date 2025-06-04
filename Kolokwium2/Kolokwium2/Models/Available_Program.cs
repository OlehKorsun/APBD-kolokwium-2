using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2.Models;

[Table("Available_Program")]
public class Available_Program
{
    [Key]
    public int AvailableProgramId { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public double Price { get; set; }
    
    [ForeignKey(nameof(WashingMachineId))]
    public Washing_Machine WashingMachine { get; set; }
    
    [ForeignKey(nameof(ProgramId))]
    public ProgramEntity ProgramEntity { get; set; }
    
    public int WashingMachineId { get; set; }
    public int ProgramId { get; set; }
    
    public ICollection<Purchase_History> PurchaseHistory { get; set; }
}