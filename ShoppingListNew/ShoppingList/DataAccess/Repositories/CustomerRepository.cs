using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        ShoppingContext _ShoppingContext;
      
        public CustomerRepository(ShoppingContext ShoppingContext)
        {
            _ShoppingContext = ShoppingContext;
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            try
            {
                return await _ShoppingContext.Set<Customer>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllCustomerAsync: " + ex.Message);
            }
        }


    }
}
