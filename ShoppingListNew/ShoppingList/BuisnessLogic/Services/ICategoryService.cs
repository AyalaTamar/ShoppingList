using DataAccess.DBModels;

namespace BuisnessLogic.Services
{
    public interface ICategoryService
    {
        public  Task<List<Category>> GetAllCategoriesAsync();
        public Task AddCategoryAsync(string CategoryName);

    }
}