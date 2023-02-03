using POS.API.CLONE.Entities;
namespace POS.API.CLONE.IRepositories
{
    public interface MovieIRepositories
    {
        Task<List<Movie_Entity>> getListMovie();
        Task<Movie_Entity> getMovieDetail(long movie_id);
        Task<Movie_Entity> movieCreate(Movie_Entity movie);
        Task<Movie_Entity> movieModify(Movie_Entity movie);
        Task<Movie_Entity> movieDelete(long movie_id);
    }
}
