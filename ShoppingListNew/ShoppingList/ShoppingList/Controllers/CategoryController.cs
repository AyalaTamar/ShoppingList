using BuisnessLogic.Services;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _CategoryService.GetAllCategoriesAsync();
        }

        [HttpPost]
        public async Task AddCategoryAsync(string CategoryName)
        {
            await _CategoryService.AddCategoryAsync(CategoryName);
        }
    }
}
