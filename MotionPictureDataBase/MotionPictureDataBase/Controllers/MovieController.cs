using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MotionPictureDataBase.DAOs;
using MotionPictureDataBase.Models;
using System.Data;
using System.Data.SqlClient;

namespace MotionPictureDataBase.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //string sqlDataSource;
        MovieDAO dao;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
            dao = new MovieDAO(_configuration);

        }

        [HttpGet]
        public JsonResult Get()
        {
            return dao.getAllMovies();
        }


        [HttpPost]
        public JsonResult Post([FromBody] Movie movie)
        {
            return dao.AddMovie(movie);
        }


        [HttpDelete("{Id}")]
        public bool DeleteMovie(int Id)
        {
            return dao.DeleteMovie(Id);
        }







        /*[HttpPost]
        public IActionResult Post([FromBody]Models.Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("InvalidData");
            }
            
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                string sql = @"insert into movie(title, description,release_year) values(@title,@description,@release_year);";
                var command = new SqlCommand(sql, myCon);
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@description", movie.Description);
                command.Parameters.AddWithValue("@release_year", movie.ReleaseYear);
                using (SqlCommand myCommand = new SqlCommand(sql, myCon))
                {

                    int rows = command.ExecuteNonQuery();
                    myCon.Close();
                    if (rows > 0)
                    {
                        return Ok("Movie Added");
                    } else
                    {
                        return BadRequest();
                    }
                }
            }

        }*/


    }
}
