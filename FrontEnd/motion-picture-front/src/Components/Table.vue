<template>
    <div class ="movie-table-div">
      <div class ='add-button-header'>
      <button class ="add-button" @click="openEdits()"><i class="fa-solid fa-plus" ></i> Add</button>
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
                  <button class="edit-button" @click="editMovie(movie)" ><i class="fa-solid fa-pen-to-square"></i></button>
                  <button class="copy-button"><i class="fa-solid fa-copy"></i></button>
                  <button class="delete-button" @click="deleteMovie(movie.ID)"><i class="fa-solid fa-trash-can"></i></button>
                  
                </td>
              </tr>
          </tbody>
        </table>
        <div>
         
         </div>
<div>
  <b-modal ref="simple" title="BootstrapVue" hide-footer hide-header><p class="my-4">{{modalTitle}}</p></b-modal>

    <b-modal ref="edits" title="Edit Movie" size="lg" scrollable @ok.prevent="submitMovie()" @hide="emptyMovieToAdd()" >
      <div>
         <form class="editForm">
          <label>Movie Name</label>
          <div>
            <input  class="w3-input" type="text" v-model="movieToAdd.Title">
          </div>
          <label>Movie Description</label>
          <div>
            <textarea class="w3-input" type="text" v-model="movieToAdd.Description"></textarea>
          </div>
           <label>Release Year</label>
          <div>
            <input class="w3-input" type="number" style="-webkit-appearance: none; -moz-appearance: textfield;" v-model="movieToAdd.ReleaseYear">
          </div>
           
        </form>
      </div>

    </b-modal>
</div>



    </div>
</template> 

<script>
import MovieService from '../Services/MovieService';
import Modal from '../Components/Modals/Modal.vue';

export default{
  data(){
    return {
      components:{
        Modal
      },
      modalTitle: "",
      movies: [],
      movieToAdd:{
        ID: 0,
        Title: null,
        Description: null,
        ReleaseYear: null
      },
      SortTitleAsc: false,
      SortDescriptionAsc: false,
      SortYearAsc: false,
    }
  },
  created(){
    this.getMovies();
    },
  
  methods:{

    makeSimpleModal(message){
      this.modalTitle = message;
      this.openModalSimple();
    },

    emptyMovieToAdd(){
      this.movieToAdd.ID = 0;
      this.movieToAdd.Title = null;
      this.movieToAdd.Description = null;
      this.movieToAdd.ReleaseYear = null;
    },
    
    getMovies(){
      MovieService.getMovies().then((response) => {
      this.movies = response.data;
    });
    },

    editMovie(movie){
      this.movieToAdd.Title = movie.Title;  
      this.movieToAdd.Description = movie.Description;
      this.movieToAdd.ReleaseYear = movie.ReleaseYear;
      this.movieToAdd.ID = movie.ID;
      this.openEdits();
    },

    submitMovie(){
      if(!this.movieToAdd.Title){
        this.makeSimpleModal("Please input the title.");
      }

      if(this.movieToAdd.ReleaseYear.toString().length!=4){
        this.makeSimpleModal("Please enter a valid year")
      }

      if(this.movieToAdd.ID==0){
      MovieService.addMovie(this.movieToAdd).then(response=>{
        this.makeSimpleModal("Movie Added to DataBase!")
        this.getMovies();
        this.closeEdits();

      }).catch((error)=>{
        if(error.response.status==415){
        this.makeSimpleModal("Missing required information")
        } else {
        this.makeSimpleModal("Something went wrong.")
        }
      })
      } else {
        MovieService.updateMovie(this.movieToAdd).then(response=>{
        this.makeSimpleModal("Movie Updated!");
        this.getMovies();
        this.closeEdits();
        }).catch((error)=>{
          this.makeSimpleModal("Could not update movie.")
          console.log(error.response)
        })
      }
    },



    openModalSimple(){
      this.$refs['simple'].show()
    },

    openEdits(){
      this.$refs['edits'].show()
    },

    closeEdits(){
      this.$refs['edits'].hide()
    },

    deleteMovie(id){
      if(confirm("Are you sure?")){
      MovieService.deleteMovie(id).then(response =>{
        if(response.data==true){
          this.getMovies();
          this.modalTitle = "Movie Deleted"
          this.openModalSimple();
        } else {
          this.modalTitle = "Failed to Delete Movie"
          this.openModalSimple();
        }
      })
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

.editForm div>*{
  width: 100%;
}

textarea{
  height: 500px;
}

</style>