﻿using MotionPictureDataBase.Models;
using System.Collections.Generic;

namespace MotionPictureDataBase.DAOs
{
    public interface IMovie
    {
        List<Movie> getAllMovies();
        Movie getMovieById(int id);

        Movie AddMovie(Movie movieToAdd);

        void updateMovie(Movie movietoUpdate);

        void deleteMovie(int id);

        ///// Connect With DAO


    }
}
