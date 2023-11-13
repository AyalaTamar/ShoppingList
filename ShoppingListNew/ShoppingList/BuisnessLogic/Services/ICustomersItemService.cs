using DataAccess.DBModels;

namespace BuisnessLogic.Services
{
    public interface ICustomersItemService
    {
        public Task AddOrUpdateItemForCustomerAsync(int customerId, int categoryId, string itemName);
        public Task<List<ItemTemp>> GetItemsByCategoryIdForCustomerAsync(int categoryId, int customerId);
        public Task<int> GetCategoryQuentity(int customerId, int categoryId);
    }
}