using DataAccess.DBModels;

namespace DataAccess.Repositories
{
    public interface ICustomersItemRepository
    {
        public Task AddOrUpdateItemForCustomerAsync(int customerId, int categoryId, string itemName);
        public Task<List<ItemTemp>> GetItemsByCategoryIdForCustomerAsync(int categoryId, int customerId);
        public Task<int> GetCategoryQuentity(int customerId, int categoryId);
    }
}