using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;

namespace Shopping_List.Repositories
{
    public class ItemRepository : IItemRepository
    {
        ShoppingContext _ShoppingContext;
        public ItemRepository(ShoppingContext ShoppingContext)
        {
            _ShoppingContext = ShoppingContext;
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            try
            {
                return await _ShoppingContext.Items.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllItemsAsync: " + ex.Message);
            }
        }

        public async Task AddItemAsync(string itemName, string categoryName)
        {
            try
            {
                // Check if an item with the same name already exists
                Item existingItem = _ShoppingContext.Items.FirstOrDefault(i => i.Name == itemName);

                if (existingItem != null)
                {
                    Console.WriteLine($"Item with name '{itemName}' already exists. Status: 401 Unauthorized");
                    throw new UnauthorizedAccessException($"Item with name '{itemName}' already exists.");
                }
                Category category = _ShoppingContext.Categories.FirstOrDefault(c => c.Name == categoryName);

                if (category == null)
                {
                    Console.WriteLine($"Category with name '{categoryName}' not found. Unable to add item.");
                    throw new InvalidOperationException($"Category with name '{categoryName}' not found.");
                }


                // If the item doesn't exist, add a new one
                Item newItem = new Item
                {
                    Name = itemName,
                    CategoryId = category.Id
                };

                _ShoppingContext.Items.Add(newItem);
                await _ShoppingContext.SaveChangesAsync();
                Console.WriteLine($"Item '{itemName}' added successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddItemAsync: " + ex.Message);
            }


        }


        public async Task UpdateItemById(Item item, int id)
        {
            try
            {
                _ShoppingContext.Items.Update(item);
                await _ShoppingContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in  UpdateItemById: " + ex.Message);
            }
        }
        public async Task DeleteItemByIdAsync(int itemId)
        {
            try
            {
                // Check if an item with the given ID exists
                Item existingItem = await _ShoppingContext.Items.FindAsync(itemId);

                if (existingItem == null)
                {
                    Console.WriteLine($"Item with ID '{itemId}' does not exist. Status: 404 Not Found");
                    //return new ActionResult("Item not found") { StatusCode = 404 };
                }

                // If the item exists, delete it
                _ShoppingContext.Items.Remove(existingItem);
                await _ShoppingContext.SaveChangesAsync();
                Console.WriteLine($"Item with ID '{itemId}' deleted successfully.");

                // Return success status code
                //return new ActionResult("Item deleted successfully") { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteItemByIdAsync: " + ex.Message);

            }
        }
    }
}
