using Kolokwium2.Data;
using Kolokwium2.DTOs;
using Kolokwium2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class CustomerService : ICustomerService
{
    private readonly ApbdContext _context;

    public CustomerService(ApbdContext context)
    {
        _context = context;
    }

public async Task<CustomerPurchasesDTO> GetCustomerPurchases(int customerId)
    {
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer == null)
        {
            throw new CustomerNotFoundException($"Nie znaleziono użytkownika o id: {customerId}");
        }

        var orders = _context.Customers
            .Include(c => c.PurchaseHistory)
                .ThenInclude(a => a.AvailableProgram)
                .ThenInclude(p => p.ProgramEntity)
            .Include(c => c.PurchaseHistory)
                .ThenInclude(a => a.AvailableProgram)
                .ThenInclude(w => w.WashingMachine).Where(o => o.CustomerId == customerId);

        var res = orders.Select(o => new CustomerPurchasesDTO()
        {
            FirstName = o.FirstName,
            LastName = o.LastName,
            PhoneNumber = o.PhoneNumber,
            Purchases = o.PurchaseHistory.Select(ph => new PurchaseDTO()
            {
                Date = ph.PurchaseDate,
                Rating = ph.Rating,
                Price = ph.AvailableProgram.Price,
                Program = new ProgramDTO()
                {
                    Duration = ph.AvailableProgram.ProgramEntity.DurationMinutes,
                    Name = ph.AvailableProgram.ProgramEntity.Name,
                },
                WashingMachine = new WashingMachineDTO()
                {
                    MaxWeight = ph.AvailableProgram.WashingMachine.MaxWeight,
                    SerialNumber = ph.AvailableProgram.WashingMachine.SerialNumber,
                }
            }).ToList()
        });
        
        return await res.FirstOrDefaultAsync();
    }
}