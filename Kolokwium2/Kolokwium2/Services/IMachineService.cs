using Kolokwium2.DTOs;

namespace Kolokwium2.Services;

public interface IMachineService
{
    Task PostMachineAsync(PostMachineRequest request);
}