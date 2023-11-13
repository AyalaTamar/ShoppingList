
using DataAccess.DBModels;
using Microsoft.Extensions.Logging;
using Shopping_List.Repositories;

namespace Shopping_List.Services
{
    public class ItemService: IItemService
    {
       
        ILogger logger;
        IItemRepository _ItemReposity;
        public ItemService(IItemRepository ItemReposity)
        {
            _ItemReposity = ItemReposity;
        }
       
        public async Task<List<Item>> GetAllItemsAsync()
        {
                return await _ItemReposity.GetAllItemsAsync();
        }

        public async Task AddItemAsync(string itemName, string categoryName)
        {
             await _ItemReposity.AddItemAsync( itemName, categoryName);
        }
      
        public async Task DeleteItemByIdAsync(int itemId)
        {
            await _ItemReposity.DeleteItemByIdAsync( itemId);
        }
    }
}
