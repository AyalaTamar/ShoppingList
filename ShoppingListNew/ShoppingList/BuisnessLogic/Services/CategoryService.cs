using DataAccess.DBModels;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{
    public class CategoryService: ICategoryService
    {
        ICategoryRepository _CategoryRepository;
        public CategoryService(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository=CategoryRepository;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _CategoryRepository.GetAllCategoriesAsync();
        }

        public async Task AddCategoryAsync(string CategoryName)
        {
             await _CategoryRepository.AddCategoryAsync(CategoryName);
        }

    }
}
