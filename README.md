
# motion-picture-dataBase #
## Data Base ##
Two free data sets were used to generate movie database:

    https://datasets.imdbws.com/

    https://data.world/priyankad0993/top-50-imdb-movies-based-on-ratings/workspace/file?filename=Top+IMDB+Movies.xlsx

The two tables were then cleaned and merged.

### Setting Up the Database ###
To set up database, open 'database_build_script.sql' in SSMS and run to build movie database. (There should be 35 rows)

<br/><br/>

## IDE:  
## Visual Studio 2022 ##


## FrameWork
### ASP.NET Core 3.1

<br></br>

### Dependencies ###
Microsoft.AspNetCore.Analyzers  \
Microsoft.AspNetCore.Components.Analyzers \
Microsoft.AspNetCore.Mvc.Analyzers\
Mircrosoft.AspNetCore.App \
Microsoft.NETCore.App \
Microsoft.AspNetCore.JsonPatch(6.0.7) \
Mircosoft.AspNetCore.Mvc.NewtonsoftJson(3.1.16) \
System.Data.SqlClient(4.8.3)

<br/><br/>

### Setting up server ###
Open project called "MotionPictureDataBase" in Visual Studio.
If in Visual Studio version 2022, make sure "IIS Express" is selected and run without debugging.
If in Visual Studio 2019, run normally, but don't close pop-up browser window.
It should bring up default browser with raw json of all movies and be on port:44387

<br/><br/>



## Front End Vue.js App


### Setting Up Front End
Open folder called "motion-picture-front" in VS Code
In a new termial run "npm install". After installation run "npm run dev" to start the app.
It should open a webpage in the default browser with a list of movies as the home page on port:8080.

<br></br>

### Dependencies ###
  axios: ^0.27.2, \
  bootstrap: ^4.6.2, \
  bootstrap-vue: ^2.22.0, \
  vue: ^2.5.11, \
  vue-router: ^3.5.4, \
  vuelidate: ^0.7.7

  <br></br>

 ### Please reach out to datpoland@gmail.com with any questions.
















