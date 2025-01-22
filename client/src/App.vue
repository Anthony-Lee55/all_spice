<script setup>
import Navbar from './components/Navbar.vue';
import { AppState } from './AppState.js';
import ModalWrapper from './components/ModalWrapper.vue';
import RecipeForm from './components/RecipeForm.vue';
import { computed } from 'vue';
import { Recipe } from './models/Recipe';
import RecipeModal from './components/RecipeModal.vue';

// const recipes = computed(() => AppState.recipes)

// const account = computed(() => AppState.account)

// const activeRecipe=computed(()=> AppState.activeRecipe)




</script>

<template>
  <header>
    <Navbar />
  </header>
  <main class="position-relative">
    <router-view />
  </main>
  <!-- <footer class="bg-dark text-light">
  </footer> -->
  <ModalWrapper modalId="recipeModal" modalTitle="Add Recipe">
    <RecipeForm />
    <RecipeModal/>
  </ModalWrapper>
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
