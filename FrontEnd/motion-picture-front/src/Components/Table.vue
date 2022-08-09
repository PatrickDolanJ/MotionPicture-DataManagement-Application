<template>
    <div class ="movie-table-div">
      <div class ='add-button-header'>
        
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
                  <button class="delete-button"><i class="fa-solid fa-trash-can"></i></button>
                </td>
              </tr>
          </tbody>
        </table>
    </div>
</template> 

<script>
import MovieService from '../Services/MovieService'

export default{
  data(){
    return {
      movies: [],
      SortTitleAsc: false,
      SortDescriptionAsc: false,
      SortYearAsc: false
    }
  },
  created(){
    MovieService.getMovies().then(resposne => {
      console.log("got the response")
      this.movies = resposne.data;
    });
  },

  methods:{

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