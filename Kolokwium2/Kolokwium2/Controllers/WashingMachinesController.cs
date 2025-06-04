using Kolokwium2.DTOs;
using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
[Route("washing-machines")]
public class WashingMachinesController : ControllerBase
{
    private readonly IMachineService _machineService;

    public WashingMachinesController(IMachineService machineService)
    {
        _machineService = machineService;
    }

    public async Task<IActionResult> PostWashingMachineAsync([FromBody] PostMachineRequest request)
    {
        try
        {
            var res = _machineService.PostMachineAsync(request);
            return Created();
        }
        catch (MachineAlreadyExistsException e)
        {
            return Conflict(e.Message);
        }
        catch (ProgramNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (DataException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
}