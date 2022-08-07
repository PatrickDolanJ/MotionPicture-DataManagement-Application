using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using MotionPictureDataBase.Models;
using System.Collections.Generic;
using System;

namespace MotionPictureDataBase.DAOs
{
    public class MovieDAO : IMovie //separated by commas
    {
        //private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;
        private readonly SqlConnection myCon;


        public MovieDAO(string connectionString)
        {
            //_configuration = configuration;
            _sqlDataSource = connectionString;  //_configuration.GetConnectionString("MotionPictureCon");
            myCon = new SqlConnection(_sqlDataSource);
        }


        public List<Movie> getAllMovies() //List<Movie>
        {
            List<Movie> output = new List<Movie>();
            string sql = @"select Top(3) id,title,description, release_year from movie order by id desc;";
            //DataTable table = new DataTable();
            string sqlDataSource = _sqlDataSource;//_configuration.GetConnectionString("MotionPictureCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(sql, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        output.Add(createMovieFromReader(myReader));
                    }


                    //table.Load(myReader);
                    //myReader.Close();
                    //myCon.Close();

                }
            }
            return output;
        }

        public Movie AddMovie(Movie movieToAdd) //give back made movie object
        {
            string sql = @"insert into movie(title, description, release_year) OUTPUT INSERTED.id, values(@title,@description,@release_year) --SELECT SCOPE_IDENTITY() as newID;"; //OUTPUT INSERTED id could also work, in fact works better?

            using (SqlConnection myCon = new SqlConnection(_sqlDataSource))

            {
                myCon.Open();
                var command = new SqlCommand(sql, myCon);
                command.Parameters.AddWithValue("@title", movieToAdd.Title);
                command.Parameters.AddWithValue("@description", movieToAdd.Description);
                command.Parameters.AddWithValue("@release_year", movieToAdd.ReleaseYear);
                using (command)
                {
                    movieToAdd.ID = Convert.ToInt32(command.ExecuteScalar());
                     
                    //myReader = command.ExecuteReader(); //could be execute scalar //should also be reader.Read() to translate to C# object 
                    //table.Load(myReader);
                    
                    myCon.Close();
                }
            }
            return movieToAdd;
        }


        public void deleteMovie(int id) //ExecuteNonQuery
        {
            string sql = @"delete from movie where id = @id;";
            SqlDataReader myReader;
            DataTable table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(_sqlDataSource))
            {
                myCon.Open();
                var command = new SqlCommand(sql, myCon);
                command.Parameters.AddWithValue("@id", id);
                using (command)
                {
                    myReader = command.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
        }


        public void updateMovie(Movie movie)
        {
            string sql = @"UPDATE movie set title = @title, description = @description, release_year = @release_year where id = @id;";
            SqlDataReader myReader;
            DataTable table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(_sqlDataSource))
            {
                myCon.Open();
                var command = new SqlCommand(sql, myCon);
                command.Parameters.AddWithValue("@id", movie.ID);
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@description", movie.Description);
                command.Parameters.AddWithValue("@release_year", movie.ReleaseYear);
                using (command)
                {
                    myReader = command.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

        }


        //mapiing function\\
        /*Movie movie = new Movie();
        cityid = Convert.ToInt32(ReadOnlyException["movie_id"])
        etc...
        return movie;
         */

        private Movie createMovieFromReader(SqlDataReader dataIn)
        {
            Movie output = new Movie();
            output.ID = Convert.ToInt32(dataIn["id"]);
            output.Title = Convert.ToString(dataIn["title"]);
            output.Description = Convert.ToString(dataIn["description"]);
            output.ReleaseYear = Convert.ToInt32(dataIn["release_year"]);
            //etc.

            return output;
        }

        public Movie getMovieById(int id)
        {
            Movie output = null;
            string sql = @"select id, title, description, release_year from movie where id = @id;";
            string sqlDataSource = _sqlDataSource;//_configuration.GetConnectionString("MotionPictureCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))

            {
                myCon.Open();
                var command = new SqlCommand(sql, myCon);
                command.Parameters.AddWithValue("@id", id);
                using (command)
                {
                    myReader = command.ExecuteReader();
                    if (myReader.Read())
                    {
                        output = createMovieFromReader(myReader);
                    }
                }
            }
            return output;
        }




    }
}
