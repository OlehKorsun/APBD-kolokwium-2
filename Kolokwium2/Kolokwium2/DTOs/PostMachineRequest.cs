namespace Kolokwium2.DTOs;

public class PostMachineRequest
{
    public WashingMachineRequest WashingMachine { get; set; }
    public List<AvailableProgramRequest> AvailablePrograms { get; set; }
}

public class WashingMachineRequest
{
    public double MaxWeight { get; set; }
    public string SerialNumber { get; set; }
}

public class AvailableProgramRequest
{
    public string ProgramName { get; set; }
    public double Price { get; set; }
}