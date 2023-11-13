using DataAccess.DBModels;

namespace BuisnessLogic.Services
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetAllCustomerAsync();
      

    }
}