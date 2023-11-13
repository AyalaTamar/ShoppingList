using DataAccess.DBModels;

namespace DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAllCustomerAsync();
    }
}