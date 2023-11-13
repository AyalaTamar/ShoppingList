using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ShoppingContext _ShoppingContext;

        public CategoryRepository(ShoppingContext ShoppingContext)
        {
            _ShoppingContext = ShoppingContext;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            try
            {
                return await _ShoppingContext.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllCategoriesAsync: " + ex.Message);
            }
        }
        public async Task AddCategoryAsync(string CategoryName)
        {
            try
            {
                // Check if an item with the same name already exists
                Category existingCategory = _ShoppingContext.Categories.FirstOrDefault(c => c.Name == CategoryName);

                if (existingCategory != null)
                {
                    Console.WriteLine($"Item with name '{CategoryName}' already exists. Status: 401 Unauthorized");
                    throw new UnauthorizedAccessException($"Item with name '{CategoryName}' already exists.");
                }

                // If the item doesn't exist, add a new one
                Category newCategory = new Category
                {
                    Name = CategoryName,
                };

                _ShoppingContext.Categories.Add(newCategory);
                await _ShoppingContext.SaveChangesAsync();
                Console.WriteLine($"Item '{CategoryName}' added successfully.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddItemAsync: " + ex.Message);
            }



        }

    }
}
