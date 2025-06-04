using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

[Table("Purchase_History")]
[PrimaryKey(nameof(CustomerId), nameof(AvailableProgramId))]
public class Purchase_History
{
    [Required]
    public DateTime PurchaseDate { get; set; }
    
    public int? Rating { get; set; }
    
    [ForeignKey(nameof(AvailableProgramId))]
    public Available_Program AvailableProgram { get; set; }
    
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }
    
    public int CustomerId { get; set; }
    public int AvailableProgramId { get; set; }
}