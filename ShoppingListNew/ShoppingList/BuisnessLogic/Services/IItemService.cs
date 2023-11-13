using DataAccess.DBModels;


namespace Shopping_List.Services
{
    public interface IItemService
    {
        public Task<List<Item>> GetAllItemsAsync();
        public Task AddItemAsync(string itemName, string categoryName);
        public Task DeleteItemByIdAsync(int itemId);
    }
}