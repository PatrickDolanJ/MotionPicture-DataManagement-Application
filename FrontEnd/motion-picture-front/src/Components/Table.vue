<template>
    <div class =movie-table>
    <div class ='add-button-header'>
    <button class ="headerutton"><i class="fa-solid fa-plus"></i></button>
    </div>
    <table class="table table-striped">
      <th scope="col">Title</th>
      <th scope="col">Description</th>
      <th scope="col">Release Year</th>
      <th scope ="col">Actions</th>
          <tr scope='row' class="movie" v-for='movie in movies'>
            <td>{{movie.Title}}</td>
            <td>{{movie.Description}}</td>
            <td>{{movie.ReleaseYear}}</td>
            <td>
              <button><i class="fa-solid fa-pen-to-square"></i></button>
              <button><i class="fa-solid fa-copy"></i></button>
              <button><i class="fa-solid fa-trash-can"></i></button>
            </td>
          </tr>
    </table>
    </div>
</template> 

<script>
import MovieService from '../Services/MovieService'

export default{
  data(){
    return {
      movies: [],
      isLoading: true
    }
  },
  created(){
    MovieService.getMovies().then(resposne => {
      console.log("got the response")
      this.movies = resposne.data;
      this.isLoading = false;
    });
  }
}

</script>


<style style="scoped">
.movie-table{
  background-color: white;
}

</style>