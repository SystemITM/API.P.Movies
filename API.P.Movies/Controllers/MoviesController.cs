using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;
using API.P.Movies.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.P.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesAsync()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
        }

    
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            if (movie == null)
                return NotFound($"La película con id {id} no existe.");

            return Ok(_mapper.Map<MovieDto>(movie));
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovieAsync(MovieCreateUpdateDto dto)
        {
            // VALIDACIONES
            if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Length > 100)
                return BadRequest("El campo 'Name' es obligatorio y no puede exceder 100 caracteres.");

            if (dto.Duration <= 0)
                return BadRequest("El campo 'Duration' es obligatorio y debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(dto.Clasification) || dto.Clasification.Length > 10)
                return BadRequest("El campo 'Clasification' es obligatorio y no puede exceder 10 caracteres.");

            // Crear entidad
            var movieEntity = _mapper.Map<Movie>(dto);
            var createdMovie = await _movieService.CreateMovieAsync(movieEntity);

            var movieDto = _mapper.Map<MovieDto>(createdMovie);

            return CreatedAtAction(nameof(GetMovieAsync), new { id = createdMovie.Id }, movieDto);
        }

     
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateMovieAsync(int id, MovieCreateUpdateDto dto)
        {
            if (!await _movieService.MovieExistsAsync(id))
                return NotFound($"La película con id {id} no existe.");

            // VALIDACIONES
            if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Length > 100)
                return BadRequest("El campo 'Name' es obligatorio y no puede exceder 100 caracteres.");

            if (dto.Duration <= 0)
                return BadRequest("El campo 'Duration' es obligatorio y debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(dto.Clasification) || dto.Clasification.Length > 10)
                return BadRequest("El campo 'Clasification' es obligatorio y no puede exceder 10 caracteres.");

            // Mapear al entity
            var existing = await _movieService.GetMovieAsync(id);
            if (existing == null)
                return NotFound($"La película con id {id} no existe."); // doble protección

            _mapper.Map(dto, existing);
            existing.UpdatedDate = DateTime.Now;

            var result = await _movieService.UpdateMovieAsync(existing);

            if (!result)
                return BadRequest("No se pudo actualizar la película.");

            return NoContent();
        }

   
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteMovieAsync(int id)
        {
            if (!await _movieService.MovieExistsAsync(id))
                return NotFound($"La película con id {id} no existe.");

            var result = await _movieService.DeleteMovieAsync(id);

            if (!result)
                return BadRequest("No se pudo eliminar la película.");

            return NoContent();
        }
    }
}
