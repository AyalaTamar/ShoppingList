using DataAccess.DBModels;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{
    public class CustomersItemService: ICustomersItemService
    {
        ICustomersItemRepository _CustomersItemRepository;
        public CustomersItemService(ICustomersItemRepository CustomersItemRepository)
        {
            _CustomersItemRepository = CustomersItemRepository;
        }
        public async Task AddOrUpdateItemForCustomerAsync(int customerId, int categoryId, string itemName)
        {
            await _CustomersItemRepository.AddOrUpdateItemForCustomerAsync(customerId, categoryId, itemName);
        }
        public async Task<List<ItemTemp>> GetItemsByCategoryIdForCustomerAsync(int categoryId, int customerId)
        {
            return await _CustomersItemRepository.GetItemsByCategoryIdForCustomerAsync(categoryId, customerId);
        }
        public async Task<int> GetCategoryQuentity(int customerId, int categoryId)
        {
            return await _CustomersItemRepository.GetCategoryQuentity(customerId, categoryId);
        }
    }
}
