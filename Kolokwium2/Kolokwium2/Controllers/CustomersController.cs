using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{customerId}/purchases")]
    public async Task<IActionResult> GetCustomerAsync(int customerId)
    {
        try
        {
            var res = await _customerService.GetCustomerPurchases(customerId);
            return Ok(res);
        }
        catch (CustomerNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}