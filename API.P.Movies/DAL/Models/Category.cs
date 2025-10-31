using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] //este dara anootation indica que el campo es obligatorio
        [Display(Name = "Categoria")] //Este decoradtor me permite cambiar el nombre de la propiedad en las vistas
        [MaxLength]
        public string Name { get; set; }
    }
}

