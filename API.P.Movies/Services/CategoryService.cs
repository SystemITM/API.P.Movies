using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;
using API.P.Movies.Repository.IRepository;
using API.P.Movies.Services.IServices;
using AutoMapper;

namespace API.P.Movies.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) {
           _categoryRepository = categoryRepository;
            _mapper = mapper;
        
        }

        public Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); //SOLO ESTOY LLAMANDO EL METODO DESDE LA CAPA DE Repository

            return _mapper.Map<ICollection<CategoryDto>>(categories);//mapeo la lista de categorias a una lista de categorias DTO

        }

        public Task<CategoryDto> GetCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
