<script setup>
import { Recipe } from '@/models/Recipe';
import ModalWrapper from './ModalWrapper.vue';
import { Account } from '@/models/Account';
import Pop from '@/utils/Pop';
import { recipesService } from '@/services/RecipesService';
import { logger } from '@/utils/Logger';
import { computed } from 'vue';
import { AppState } from '@/AppState';
import RecipeModal from './RecipeModal.vue';
import { Modal } from 'bootstrap';
import { ingredientsService } from '@/services/IngredientsService';
import { favoritesService } from '@/services/FavoritesService';


const props = defineProps({
  recipe: { type: Recipe, required: true }
})

const hasFavorited = computed(() => AppState.favoriteRecipes.some(favoriteRecipe => favoriteRecipe.id == props.recipe.id))

const account = computed(() => AppState.account)

const activeRecipe = computed(() => AppState.activeRecipe)

async function getRecipeById(recipeId) {
  try {
    await recipesService.getRecipeById(recipeId)
    getIngredientsForRecipe(recipeId)
    Modal.getInstance('#recipeDetailModal').show()
  }
  catch (error) {
    Pop.meow(error);
    logger.error("GETTING RECIPE BY ID", error)
  }
}

async function getIngredientsForRecipe(recipeId) {
  try {
    await recipesService.getIngredientsForRecipe(recipeId)
  }
  catch (error) {
    Pop.meow(error);
    logger.error("GETTING INGREDIENTS FOR RECIPE", error)
  }
}

async function createFavorite() {
  try {
    const favoriteData = { recipeId: props.recipe.id }
    await favoritesService.createFavorite(favoriteData)
  }
  catch (error) {
    Pop.meow(error);
    logger.error("CREATING FAVORITE", error)
  }
}

async function deleteFavorite(favorite) {
  try {
    await favoritesService.deleteFavorite(favorite)
  }
  catch (error) {
    Pop.meow(error);
    logger.error("DELETING FAVORITE", error)
  }
}


</script>


<template>
  <div v-if="recipe" @click="getRecipeById(recipe.id)" data-bs-toggle="modal" data-bs-target="#recipeDetailModal"
    role="button" class="card shadow-lg d-flex" :style="{ backgroundImage: `url(${recipe.img})` }">
    <div class="d-flex align-items-start justify-content-between">
      <div class="text-light text-capitalize category">
        {{ recipe.category }}
      </div>
      <div>
        <label class="container ">
          <input @click="createFavorite()" checkmark="checked" type="checkbox">
          <div class="checkmark mt-2 text-shadow ">
            <svg viewBox="0 0 256 256">
              <rect fill="none" height="256" width="256"></rect>
              <path
                d="M224.6,51.9a59.5,59.5,0,0,0-43-19.9,60.5,60.5,0,0,0-44,17.6L128,59.1l-7.5-7.4C97.2,28.3,59.2,26.3,35.9,47.4a59.9,59.9,0,0,0-2.3,87l83.1,83.1a15.9,15.9,0,0,0,22.6,0l81-81C243.7,113.2,245.6,75.2,224.6,51.9Z"
                stroke-width="20px" stroke="#FFF" fill="none"></path>
            </svg>
          </div>
        </label>
      </div>
    </div>
    <div class="title text-light text-capitalize d-flex align-items-end">
      {{ recipe.title }}
    </div>
  </div>
  <RecipeModal />
</template>


<style lang="scss" scoped>
.card {
  min-height: 20vh;
  background-position: center;
  background-size: cover;
  margin: 1.75em;
  border: none;
}

.recipe-detail-img {
  object-fit: cover;
  object-position: center;
  width: 100%;
  aspect-ratio: 1/1;
  min-height: 30dvh;
}

.recipe-detail-header {
  color: #6e662766;
  text-shadow: 1px 1px rgba(0, 0, 0, 0.361);
}

.category {
  backdrop-filter: blur(10px);
  margin: 1em;
  padding: 0.25em;
  padding-left: 0.5em;
  padding-right: 0.5em;
  border-radius: 50px;
  text-shadow: 1px 1px rgba(0, 0, 0, 0.361);
}

.title {
  backdrop-filter: blur(10px);
  margin: 1em;
  padding: 0.5em;
  padding-left: 0.5em;
  padding-right: 0.5em;
  border-radius: 5px;
  text-shadow: 1px 1px rgba(0, 0, 0, 0.361);
  position: absolute;
  bottom: 0;
  width: 90%;
}

.heart {
  flex-direction: row-reverse;
}

.container input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
  height: 0;
  width: 0;
}

.container {
  display: block;
  position: relative;
  cursor: pointer;
  font-size: 20px;
  user-select: none;
  transition: 100ms;
}

.checkmark {
  top: 0;
  left: 0;
  height: 2em;
  width: 2em;
  transition: 100ms;
  animation: dislike_effect 400ms ease;
}

.container input:checked~.checkmark path {
  fill: #FF5353;
  stroke-width: 0;
}

.container input:checked~.checkmark {
  animation: like_effect 400ms ease;
}

.container:hover {
  transform: scale(1.1);
}

@keyframes like_effect {
  0% {
    transform: scale(0);
  }

  50% {
    transform: scale(1.2);
  }

  100% {
    transform: scale(1);
  }
}

@keyframes dislike_effect {
  0% {
    transform: scale(0);
  }

  50% {
    transform: scale(1.2);
  }

  100% {
    transform: scale(1);
  }
}
</style>