using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using MotionPictureDataBase.Models;


namespace MotionPictureDataBase.DAOs
{
    public class MovieDAO
    {
        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;
        private readonly SqlConnection myCon;


        public MovieDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("MotionPictureCon");
            myCon = new SqlConnection(_sqlDataSource);
        }


        public JsonResult getAllMovies()
        {
            string sql = @"select Top(3) id,title,description, release_year from movie order by id desc;";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MotionPictureCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(sql, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }

        public JsonResult AddMovie(Movie movie)
        {
            string sql = @"insert into movie(title, description, release_year) values(@title,@description,@release_year) SELECT SCOPE_IDENTITY() as newID;";
            SqlDataReader myReader;
            DataTable table = new DataTable();
            using (SqlConnection myCon = new SqlConnection(_sqlDataSource))
            {
                myCon.Open();
                var command = new SqlCommand(sql, myCon);
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
            return new JsonResult(table);
        }


        /*public IActionResult DeleteMovie(int id)
        {

        }*/





    }
    }
