using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CustomersItemRepository : ICustomersItemRepository
    {
        ShoppingContext _ShoppingContext;
        public CustomersItemRepository(ShoppingContext ShoppingContext)
        {
            _ShoppingContext = ShoppingContext;
        }

        public async Task AddOrUpdateItemForCustomerAsync(int customerId, int categoryId, string itemName)
        {
            try
            {

                // Check if the item already exists in the product table
                var item = _ShoppingContext.Items
                    .FirstOrDefault(i => i.Name == itemName);
                await UpdateCategoryQuentity(customerId, categoryId);
                if (item == null)
                {
                    // Item does not exist in the product table, add it
                    var newItem = new Item
                    {
                        CategoryId = categoryId,
                        Name = itemName
                    };

                    _ShoppingContext.Items.Add(newItem);
                    await _ShoppingContext.SaveChangesAsync();

                    // Assign the new item to the 'item' variable
                    item = newItem;
                }

                // Check if the item already exists for the customer
                var customerItem = _ShoppingContext.CustomersItems
                    .FirstOrDefault(ci => ci.CustomerId == customerId && ci.ItemId == item.Id);

                if (customerItem != null)
                {
                    // Item already exists for the customer, update the quantity
                    customerItem.Quantity += 1;
                }
                else
                {
                    // Item does not exist for the customer, add a new entry
                    _ShoppingContext.CustomersItems.Add(new CustomersItem
                    {
                        CustomerId = customerId,
                        ItemId = item.Id,
                        Quantity = 1
                    });
                }

                await _ShoppingContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddOrUpdateItemForCustomer: " + ex.Message);
            }
        }

        public async Task UpdateCategoryQuentity(int customerId, int categoryId)
        {
            // Find the category by ID
            Category category = _ShoppingContext.Categories.FirstOrDefault(ci => ci.Id == categoryId);

            // Check if the category with the given ID exists
            if (category != null)
            {
                // Update the quantity
                category.Sum += 1;

                // Save changes to the database
                await _ShoppingContext.SaveChangesAsync();
            }
        }
        public async Task<int> GetCategoryQuentity(int customerId, int categoryId)
        {
            // Find the category by ID
            Category category = _ShoppingContext.Categories.FirstOrDefault(ci => ci.Id == categoryId);
            if (category != null)
                return category.Sum;
            else return 0;
        }

        public async Task<List<ItemTemp>> GetItemsByCategoryIdForCustomerAsync(int categoryId, int customerId)
        {
            var items = from ci in _ShoppingContext.CustomersItems
                        join item in _ShoppingContext.Items on ci.ItemId equals item.Id
                        where ci.CustomerId == customerId && item.CategoryId == categoryId
                        select new ItemTemp
                        {
                            CustomerId = ci.CustomerId,
                            ItemId = ci.ItemId,
                            Name = item.Name,
                            Quantity = ci.Quantity
                        };

            return await items.ToListAsync();
        }

    }
}
