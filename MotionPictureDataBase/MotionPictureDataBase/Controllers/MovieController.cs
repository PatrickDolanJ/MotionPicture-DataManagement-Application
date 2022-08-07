using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MotionPictureDataBase.DAOs;
using MotionPictureDataBase.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MotionPictureDataBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovie MovieDAO { get; }
        public MovieController(IMovie movieDAO) //dependecy injection
        {
            this.MovieDAO = movieDAO;
        }
        // GET: api/<Movie2Controller>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
           return MovieDAO.getAllMovies();
        }

        // GET api/<Movie2Controller>/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return MovieDAO.getMovieById(id);
        }

        // POST api/<Movie2Controller>
        [HttpPost]
        public Movie Post([FromBody] Movie movie)
        {
            return MovieDAO.AddMovie(movie);
        }

        // PUT api/<Movie2Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie movie)
        {
            MovieDAO.updateMovie(movie);
        }

        // DELETE api/<Movie2Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MovieDAO.deleteMovie(id);
        }
    }
}
