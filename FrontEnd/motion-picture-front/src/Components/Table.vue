<template>
    <div class ="movie-table-div">
      <div class ='add-button-header'>
      <button class ="add-button" @click="emptyMovieToAdd();  openEdits()"><i class="fa-solid fa-plus" ></i> Add</button>
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
                  <button class="copy-button" @click="copyMovie(movie)"><i class="fa-solid fa-copy"></i></button>
                  <button class="delete-button" @click="deleteMovie(movie)"><i class="fa-solid fa-trash-can"></i></button>
                  
                </td>
              </tr>
          </tbody>
        </table>
        <div>
         
      </div>
   <div>

      <b-modal ref="simple" hide-footer hide-header><p>{{modalTitle}}</p></b-modal>


      <b-modal ref="edits" title="Edit Movie" size="lg" scrollable @ok.prevent="submitMovie()" @hide="formClose()" >
          <b-form-group class="editTitle" label="Title" label-for = 'movieTitleInput' ref="form" >
              <b-form-input  id='movieTitleInput' type="text" v-model="movieToAdd.Title" :state="validateState('Title')" aria-describedby="title-feedback"
              ></b-form-input>
              <b-form-invalid-feedback id="title-feedback">Title is required, 50 character limit.</b-form-invalid-feedback>

            </b-form-group>

            <b-form-group class="editDescription" label="Description" label-for = 'movieDescriptionInput' >
              <b-form-textarea class="descriptionInput" type="text" v-model="movieToAdd.Description"
              :state="validateState('Description')" aria-describedby="description-feedback" style="height:450px;"></b-form-textarea>
              <b-form-invalid-feedback id="description-feedback">Description must be no larger than 500 characters</b-form-invalid-feedback>
            </b-form-group>

            <b-form-group class="editTitle" label="Year" label-for = 'movieYearInput' >
              <b-form-input id="movieYearInput" type="number" style="-webkit-appearance: none; -moz-appearance: textfield;" v-model="movieToAdd.ReleaseYear" 
              :state="validateState('ReleaseYear')" aria-describedby="year-feedback"></b-form-input>
              <b-form-invalid-feedback id="year-feedback">Please enter a valid year (YYYY).</b-form-invalid-feedback>
            </b-form-group>
            <footer>
              <b-button v-if="movieToAdd.ID!=0" variant='danger' @click="deleteMovie(movieToAdd); closeEdits();">Delete</b-button>
            </footer>
      </b-modal>
    </div>
  </div>
</template> 

<script>
import MovieService from '../Services/MovieService';

import { validationMixin } from "vuelidate";
import { required, minLength, maxLength } from "vuelidate/lib/validators";


export default{
  mixins: [validationMixin],
  data(){
    return {
     
      titleState: null,
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
  validations: {
    movieToAdd: {
      Title: {
        required,
        minLength: minLength(1),
        maxLength: maxLength(50)
      },
      ReleaseYear: {
      required, 
      minLength: minLength(4)
    },
      Description:{
        maxLength: maxLength(500)
      }
  }
  },
  created(){
    this.getMovies();
    },
  
  methods:{

    formClose(){
        this.getMovies(); 
    },
    validateState(name) {
      const { $dirty, $error } = this.$v.movieToAdd[name];
      return $dirty ? !$error : null;
    },

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

    copyMovie(movie){
      this.movieToAdd.Title = movie.Title;  
      this.movieToAdd.Description = movie.Description;
      this.movieToAdd.ReleaseYear = movie.ReleaseYear;
      this.openEdits();
    },

    submitMovie(){
        this.$v.movieToAdd.$touch();

       if (this.$v.movieToAdd.$invalid){
        console.log()
        return;
       }

      if(this.movieToAdd.ID==0){
      MovieService.addMovie(this.movieToAdd).then(response=>{
        this.makeSimpleModal("Movie Added to DataBase!")
        //this.getMovies();
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
        //this.getMovies();
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
      this.$v.$reset();
      this.$refs['edits'].show()
    },

    closeEdits(){
      this.$refs['edits'].hide()
    },

    deleteMovie(movie){
      if(confirm("Are you sure you want to delete "+movie.Title+"?")){
      MovieService.deleteMovie(movie.ID).then(response =>{
          this.getMovies();
          this.modalTitle = "Movie Deleted"
          this.openModalSimple();
        }).catch((error)=>{
            this.modalTitle = "Failed to Delete Movie"
            this.openModalSimple();
            console.log(error.response)
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

</style>