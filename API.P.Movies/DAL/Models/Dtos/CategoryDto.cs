using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models.Dtos
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "El Nombre de la categoria es obligarotuia")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100.")]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
