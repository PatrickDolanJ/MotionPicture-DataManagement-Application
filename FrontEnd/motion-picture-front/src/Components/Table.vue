<template>
    <div class =movie-table>
    <div class ='add-button-header'>
    <button class ="headerutton"><i class="fa-solid fa-plus"></i></button>
    </div>
    <table class="table table-striped">
      <th scope="col">Title</th>
      <th scope="col">Description</th>
      <th scope="col">Release Year</th>
      <th scopre ="col">Actions</th>
      <tr v-for="movie in movies"></tr>
      <td>{{movie.title}}</td>
      <td>{{movie.description}}</td>
      <td>{{movie.release_year}}</td>
      <td>
        <button><i class="fa-solid fa-pen-to-square"></i></button>
        <button><i class="fa-solid fa-copy"></i></button>
        <button><i class="fa-solid fa-trash-can"></i></button>
      </td>
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
      this.isLoading = false;
    });
  }
}

</script>


<style style="scoped">


</style>