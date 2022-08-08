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
        private readonly string _sqlDataSource;
        private readonly SqlConnection _myCon;


        public MovieDAO(string connectionString)
        {
            _sqlDataSource = connectionString;  
            _myCon = new SqlConnection(_sqlDataSource);
        }


        public List<Movie> getAllMovies() 
        {
            List<Movie> output = new List<Movie>();
            string sql = @"select id,title,description, release_year from movie order by id desc;";
            string sqlDataSource = _sqlDataSource;
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
                    myCon.Close();
                }
            }
            return output;
        }

        public Movie AddMovie(Movie movieToAdd)
        {
            string sql = @"insert into movie(title, description, release_year) OUTPUT INSERTED.id values(@title,@description,@release_year);";

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
                    myCon.Close();
                }
            }
            return movieToAdd;
        }


        public void deleteMovie(int id) 
        {
            string sql = @"delete from movie where id = @id;";
            using (SqlConnection myCon = new SqlConnection(_sqlDataSource))
            {
                myCon.Open();
                var command = new SqlCommand(sql, myCon);
                command.Parameters.AddWithValue("@id", id);
                using (command)
                {
                    command.ExecuteNonQuery();
                    myCon.Close();
                }
            }
        }


        public void updateMovie(int id, Movie movieToUpdate)
        {
            string sql = @"UPDATE movie set title = @title, description = @description, release_year = @release_year where id = @id;";
            using (SqlConnection myCon = new SqlConnection(_sqlDataSource))
            {
                myCon.Open();
                var command = new SqlCommand(sql, myCon);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@title", movieToUpdate.Title);
                command.Parameters.AddWithValue("@description", movieToUpdate.Description);
                command.Parameters.AddWithValue("@release_year", movieToUpdate.ReleaseYear);
                using (command)
                {
                    command.ExecuteNonQuery();
                    myCon.Close();
                }
            }

        }


        public Movie getMovieById(int id)
        {
            Movie output = null;
            string sql = @"select id, title, description, release_year from movie where id = @id;";
            string sqlDataSource = _sqlDataSource;
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

        private Movie createMovieFromReader(SqlDataReader dataIn)
        {
            Movie output = new Movie();
            output.ID = Convert.ToInt32(dataIn["id"]);
            output.Title = Convert.ToString(dataIn["title"]);
            output.Description = Convert.ToString(dataIn["description"]);
            output.ReleaseYear = Convert.ToInt32(dataIn["release_year"]);

            return output;
        }

    }
}
