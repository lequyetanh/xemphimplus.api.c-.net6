using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using POS.API.CLONE.Entities;
using POS.API.CLONE.IRepositories;

namespace POS.API.CLONE.Repositories
{
    public class MovieRepositories:MovieIRepositories
    {
    private readonly ApplicationContext _context;

        public MovieRepositories(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Movie_Entity>> getListMovie()
        {
            List<Movie_Entity> listMovie = new List<Movie_Entity>();
            listMovie = _context.Movie_Object.ToList();
            return listMovie;
        }

        public async Task<Movie_Entity> getMovieDetail(long movie_id)
        {
            Movie_Entity movie = _context.Movie_Object.FirstOrDefault(r => r.id == movie_id);
            return movie;
        }

        public async Task<Movie_Entity> movieCreate(Movie_Entity movie)
        {
            System.Console.WriteLine(movie);
            _context.Movie_Object.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public async Task<Movie_Entity> movieModify(Movie_Entity movie)
        {
            var movieUpdate = await _context.Movie_Object.FirstOrDefaultAsync(r => r.id == movie.id);

            _context.Movie_Object.Update(movie);
            _context.SaveChanges();
            return movieUpdate;
        }

        public async Task<Movie_Entity> movieDelete(long movie_id)
        {
            var movie = _context.Movie_Object.FirstOrDefault(r => r.id == movie_id);
            _context.Movie_Object.Remove(movie);
            _context.SaveChanges();
            return movie;
        }
    }

}
