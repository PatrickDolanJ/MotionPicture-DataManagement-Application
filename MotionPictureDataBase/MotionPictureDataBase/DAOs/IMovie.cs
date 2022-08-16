using MotionPictureDataBase.Models;
using System.Collections.Generic;

namespace MotionPictureDataBase.DAOs
{
    public interface IMovie
    {
        List<Movie> getAllMovies();
        Movie getMovieById(int id);

        Movie AddMovie(Movie movieToAdd);

        void updateMovie(int id, Movie movietoUpdate);

        bool deleteMovie(int id);
    }
}
