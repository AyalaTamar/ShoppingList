using DataAccess.DBModels;


namespace Shopping_List.Repositories
{
    public interface IItemRepository
    {
        public  Task<List<Item>> GetAllItemsAsync();
        public Task AddItemAsync(string itemName, string categoryName);
        public Task DeleteItemByIdAsync(int itemId);
    }
}