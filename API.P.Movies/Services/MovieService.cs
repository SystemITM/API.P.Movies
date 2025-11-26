using API.P.Movies.DAL.Models;
using API.P.Movies.Repository.IRepository;
using API.P.Movies.Services.IServices;


namespace API.P.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _repository.GetMoviesAsync();
        }

        public async Task<Movie?> GetMovieAsync(int id)
        {
            return await _repository.GetMovieAsync(id);
        }

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            return await _repository.CreateMovieAsync(movie);
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            return await _repository.UpdateMovieAsync(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            return await _repository.DeleteMovieAsync(id);
        }

        public async Task<bool> MovieExistsAsync(int id)
        {
            return await _repository.MovieExistsAsync(id);
        }
    }
}
