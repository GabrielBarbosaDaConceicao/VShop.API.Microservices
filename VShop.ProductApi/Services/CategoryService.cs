using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories.Interfaces;
using VShop.ProductApi.Services.Interfaces;

namespace VShop.ProductApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            IEnumerable<Category> categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            IEnumerable<Category> categoriesEntity = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            Category categoryEntity = await _categoryRepository.GetById(id);
           return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task AddCategory(CategoryDTO categoryDto)
        {
            Category categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
            categoryDto.CategoryId = categoryEntity.CategoryId;
        }
        
        public async Task UpdateCategory(CategoryDTO categoryDto)
        {
            Category categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
        }

        public async Task RemoveCategory(int id)
        {
            Category categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Delete(categoryEntity.CategoryId);
        }
    }
}
