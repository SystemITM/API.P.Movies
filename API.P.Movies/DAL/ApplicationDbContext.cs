using API.P.Movies.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API.P.Movies.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Seccion para crear el dbset de lñas entidades o modelos

        public DbSet<Category>Categories { get; set; }


       
    }
}
