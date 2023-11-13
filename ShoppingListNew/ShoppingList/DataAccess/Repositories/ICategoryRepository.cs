using DataAccess.DBModels;

namespace DataAccess.Repositories
{
    public interface ICategoryRepository
    {
        public  Task<List<Category>> GetAllCategoriesAsync();
        public  Task AddCategoryAsync(string CategoryName);
    }
}