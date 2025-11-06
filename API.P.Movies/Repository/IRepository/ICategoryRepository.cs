using API.P.Movies.DAL.Models;

namespace API.P.Movies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>>GetCategoriesAsync();//Me retora una lista de categorias
        Task<Category>GetCategoryAsync(int id); //me retorna una categoria por su id
        Task<bool> CategoryExistsByIdAsync(int id);//Me dice si una categoria existe por su id
        Task<bool>CategoryExistsByNameAsync(string name);//Me dice si una categoria existe por su id
        Task<bool>CreateCategoryAsync(Category category);// Me crea una categoria
        Task<bool>UpdateCategoryAsync(Category category);//Me actualiza una categoria
        Task<bool>DeleteCategoryAsync(int id);//Me elimina una categoria
    }
}
