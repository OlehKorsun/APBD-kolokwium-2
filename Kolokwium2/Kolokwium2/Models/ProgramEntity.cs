using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Kolokwium2.Models;

[Table("Program")]
public class ProgramEntity
{
    [Key]
    public int ProgramId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    public int DurationMinutes { get; set; }
    
    [Required]
    public int TemperatureCelsius { get; set; }
    
    public ICollection<Available_Program> AvailablePrograms { get; set; }
}