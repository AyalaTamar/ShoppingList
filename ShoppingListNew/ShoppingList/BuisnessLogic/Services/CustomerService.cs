using DataAccess.DBModels;
using DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        ILogger logger;
        ICustomerRepository _CustomerRepository;
        public CustomerService(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _CustomerRepository.GetAllCustomerAsync();
        }
    }
}
