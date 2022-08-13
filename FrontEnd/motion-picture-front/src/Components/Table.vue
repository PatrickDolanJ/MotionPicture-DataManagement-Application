<template>
    <div class ="movie-table-div">
      <div class ='add-button-header'>
      <modal v-show="visible" @close="close"></modal>
      <button class ="add-button"><i class="fa-solid fa-plus"></i> Add</button>
      </div>
        <table id="movie-table" class="table table-striped table-dark table-sm">
          <thead class="thead-dark">
            <tr>
              <th scope="col"><button @click="sortResults('Title')" type="button">Title</button></th>
              <th scope="col"><button @click="sortResults('Description')" type="button">Description</button></th>
              <th scope="col"><button @click="sortResults('ReleaseYear')" type="button">Release Year</button></th>
              <th scope ="col">Actions</th>
            </tr>
          </thead>
          <tbody>
              <tr scope='row' class="movie" v-for='movie in movies' v-bind:key="movie.ID">
                <td class="movie-title">{{movie.Title}}</td>
                <td class="movie-description">{{movie.Description}}</td>
                <td class="moviie-release-year">{{movie.ReleaseYear}}</td>
                <td class="action-buttons">
                  <button class="edit-button"><i class="fa-solid fa-pen-to-square"></i></button>
                  <button class="copy-button"><i class="fa-solid fa-copy"></i></button>
                  <button class="delete-button" @click="deleteMovie(movie.ID)"><i class="fa-solid fa-trash-can"></i></button>
                  
                </td>
              </tr>
          </tbody>
        </table>
    </div>





</template> 

<script>
import MovieService from '../Services/MovieService';
import Modal from '../Components/Modals/Modal.vue';
//import  Component  from 'vue-class-component';

export default{
  data(){
    return {
      components:{
        Modal
      },
      visible: false,
      movies: [],
      movieToAdd:{
        ID: null,
        Title: null,
        Description: null,
        ReleaseYear: null
      },
      SortTitleAsc: false,
      SortDescriptionAsc: false,
      SortYearAsc: false,
      showDelete: false
    }
  },
  created(){
    this.getMovies();
    },
  
  methods:{
    getMovies(){
      MovieService.getMovies().then((response) => {
      this.movies = response.data;
    });
    },

    openModal(){
      this.visible = true;
    },

    close(){
      this.visible = false;

    },

    deleteMovie(id){
      if(confirm("Are you sure?")){
      MovieService.deleteMovie(id).then(response =>{
        if(response.data==true){
          this.getMovies();
          this.showDelete = true;
          this.openModal();
        } else {
            /* the opposite */
        }
      }
      )
      }
    },

    sortResults(sorter,asc) {
      asc = null;
      
      if(sorter=='Title'){
        this.SortTitleAsc = !this.SortTitleAsc;
        asc=this.SortTitleAsc;
      } else if (sorter==='Description'){
        this.SortDescriptionAsc = !this.SortDescriptionAsc;
        asc = this.SortDescriptionAsc;
      } else {
        this.SortYearAsc = !this.SortYearAsc;
        asc = this.SortYearAsc;
      }
     

      this.movies =this.movies.sort(function(a,b){
        if(asc){
          return (a[sorter]>b[sorter]) ? 1 : (a[sorter]<b[sorter] ? -1 : 0);
        } else {
          return (b[sorter]>a[sorter]) ? 1 : (b[sorter]<a[sorter] ? -1 : 0);
        }
      })
      }

    }
  }


</script>


<style style="scoped">

.movie-table{
  background-color: white;
  
}

.add-button-header{
display: flex;
justify-content: right;

margin-top: 10px;
background-color: #212529;
border-top-left-radius: 5px;
border-top-right-radius: 5px;
height: fit-content;
}
.add-button{
  background-color: #6273a3;
  margin: 10px;
  border-radius: 5px;
  width: 8%;
  height: 75%;
  border: none;
  height: 40px;
  
}

table button{
  background: none;
  border: none;
  color: white;
}

.thead-dark button:hover{
 color:cornflowerblue;
 font-weight: 600;
}

.thead-dark {
font-family: "Avenir", Helvetica, Arial, sans-serif;
font-size: 20px;
}


.action-buttons button:hover{
  background-color: cornflowerblue;
}


.delete-button{
  color:crimson;
}

.movie-table-div{
  margin: 200px;
  margin-top: 0px;
}

.action-buttons{
width:100px;
align-items: center;
}

.moviie-release-year{
  width: 150px;
}
</style>