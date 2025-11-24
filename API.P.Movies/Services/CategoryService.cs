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

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        /*
        public async Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
        */

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto CategoryCreateDto)
        {
          //Validar si la categoria ya existe
         var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(CategoryCreateDto.Name);

            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{CategoryCreateDto.Name}'");
            }

            //Mapear el DTO a la entidad
            var category = _mapper.Map<Category>(CategoryCreateDto);

            //crear la categoria en el repositorio

           var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Ocurrio un erro al crear la categoria");
            }

            //Mapear la entidad al DTO

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); //SOLO ESTOY LLAMANDO EL METODO DESDE LA CAPA DE Repository

            return _mapper.Map<ICollection<CategoryDto>>(categories);//mapeo la lista de categorias a una lista de categorias DTO

        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            //Obtener la categoriadel repositorio
            var category = await _categoryRepository.GetCategoryAsync(id); 

            //mapear toda la collecion de una vez
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
