<script setup>
import { computed, onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import SearchBar from './SearchBar.vue';
import { AppState } from '@/AppState.js';

const account = computed(() => AppState.account)

</script>

<template>
  <nav class="navbar navbar-expand-sm navbar-dark">
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse justify-content-end" id="navbarText">
    </div>
  </nav>
  <div class="container header-img">
    <div class="d-flex justify-content-end">
      <button v-if="account" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#recipeModal"><i
          class="mdi mdi-plus-circle"></i></button>
      <SearchBar />
      <Login />
    </div>
    <section class="row d-flex justify-content-center text-light p-5 shadow-lg">
      <div class="col-md-3 header-text">
        <h1>All-Spice</h1>
        <p>Cherish Your Family</p>
        <p>And Their Cooking</p>
      </div>
    </section>
  </div>
</template>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}

.header-img {
  background-image: url(https://images.unsplash.com/photo-1655815349053-9c7be24974e9?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjYzfHx3aGVhdHxlbnwwfHwwfHx8Mg%3D%3D);
  background-size: cover;
  background-position: center;
  border-radius: 0.5em;
  min-height: 20vh;
}

.header-text {
  text-shadow: 2px 2px black;
  justify-items: center;
}
</style>
