using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;
using AutoMapper;

namespace API.P.Movies.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers() 
        {
            //GATEGORY
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();

            //MOVIE

            CreateMap<Movie, MovieDto>().ReverseMap(); // Entity → DTO (respuesta)
            CreateMap<Movie, MovieCreateUpdateDto>().ReverseMap(); // DTO → Entity (crear/actualizar)
        }
    }
}
