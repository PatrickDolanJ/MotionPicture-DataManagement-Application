<template>
  <div id="app">
    <header class ='header'>
    <i class="fa-solid fa-clapperboard fa-2x"></i>
    <h1>Motion Picture Data Management</h1>
    </header>
    <router-view/>
  </div>
</template>

<script>
export default {}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  
  
}
.header{
  display: flex;
  align-items: center;
  padding-left: 20px;
  position: fixed-top;
  background-color: #6273a3;
  padding-bottom: 15px;
  padding-top: 15px;
}

h1, h2 {
  font-weight: normal;
  font-family:Verdana, Geneva, Tahoma, sans-serif ;
  margin: 0px;
  margin-left: 10px;
}

html{
  height: 100%;
}
body{
background: #6273a3;
background: -webkit-linear-gradient(top, #6273a3, #242b3d);
background: -moz-linear-gradient(top, #6273a3, #242b3d);
background: linear-gradient(to bottom, #6273a3, #242b3d);
margin: 0px;
}
</style>
