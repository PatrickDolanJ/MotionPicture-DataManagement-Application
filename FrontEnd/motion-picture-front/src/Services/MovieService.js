import axios from 'axios';

const http = axios.create({
baseURL:"http://localhost:58237/api/"
});

export default {

getMovies(){
    return http.get('movie');
},
getMovieById(id){
    return http.get('movie/${id}');
},

addMovie(movie){
    return http.post('movie',movie);
},

updateMovie(movie){
    return http.put(`movie/${movie.ID}`, movie);
},

deleteMovie(movieId){
    return http.delete(`movie/${movieId}`);
}
}
