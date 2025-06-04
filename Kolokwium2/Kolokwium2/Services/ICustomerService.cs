using Kolokwium2.DTOs;

namespace Kolokwium2.Services;

public interface ICustomerService
{
    Task<CustomerPurchasesDTO> GetCustomerPurchases(int customerId);
}