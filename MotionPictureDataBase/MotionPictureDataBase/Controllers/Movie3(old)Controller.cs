/*using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MotionPictureDataBase.DAOs;
using MotionPictureDataBase.Models;
using System.Data;
using System.Data.SqlClient;

namespace MotionPictureDataBase.Controllers
{

    //[Route("api/[controller]")]
    //[ApiController]
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

        //change to httpresponse
        [HttpDelete("{id}")]
        public bool DeleteMovie(int id)
        {
            return dao.DeleteMovie(id);
        }

        //change to httpResponse
        [HttpPut("{id}")]
        public bool UpdateMovie([FromBody] Movie movie)
        {
            return dao.UpdateMovie(movie);
        }

        //path variables (if primitive look in path, if not look in body)









    }
}
*/