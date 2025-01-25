<script setup>
import { AppState } from '@/AppState';
import FoodCard from '@/components/FoodCard.vue';
import RecipeModal from '@/components/RecipeModal.vue';
import { accountService } from '@/services/AccountService';
import { recipesService } from '@/services/RecipesService';
import { logger } from '@/utils/Logger';
import Pop from '@/utils/Pop';
import { computed, onMounted, ref } from 'vue';

const recipes = computed(() => {
  if (activeFilterCategory.value == 'home') return AppState.recipes
  if (activeFilterCategory.value == 'myRecipes') return AppState.recipes.filter(recipe => recipe.creatorId == account.value.id)
  return AppState.favoriteRecipes
}
)

const activeFilterCategory = ref('home')

const account = computed(() => AppState.account)

const activeRecipe = computed(() => AppState.activeRecipe)

onMounted(() => {
  getRecipes()
})

async function getRecipes() {
  try {
    await recipesService.getRecipes()
  }
  catch (error) {
    Pop.meow(error);
    logger.error("GETTING RECIPES", error.message)
  }
}

async function getFavoriteRecipes() {
  try {
    await accountService.getFavoriteRecipes()
  }
  catch (error) {
    Pop.meow(error);
    logger.error("GETTING FAVORITE RECIPES", error.message)

  }
}
</script>

<template>
  <div class="container">
    <section class="row">
      <div class="d-flex justify-content-center">
        <div class="btn-group col-md-4">
          <button @click="activeFilterCategory = 'home'" class="btn left" type="button">Home</button>
          <button @click="activeFilterCategory = 'myRecipes'" class="btn middle" type="button">My Recipes</button>
          <button @click="getFavoriteRecipes(), activeFilterCategory = 'hello'" class="btn right"
            type="button">Favorites</button>
        </div>
      </div>
    </section>

    <section class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-md-4">
        <FoodCard :recipe="recipe" />
      </div>
    </section>
    <button v-if="account" class="btn btn-success m-2 sticky-bottom" data-bs-toggle="modal"
      data-bs-target="#recipeModal"><i class="mdi mdi-plus-circle"></i></button>
  </div>
  <RecipeModal />
</template>

<style scoped lang="scss">
.btn {
  font: inherit;
  background-color: #f0f0f0;
  border: 0;
  color: #6e662766;
  font-size: 1.15rem;
  padding: 0.375em 1em;
  text-shadow: 0 0.0625em 0 #6e662766;
  box-shadow: inset 0 0.0625em 0 0 #f4f4f4, 0 0.0625em 0 0 #efefef,
    0 0.125em 0 0 #ececec, 0 0.25em 0 0 #e0e0e0, 0 0.3125em 0 0 #dedede,
    0 0.375em 0 0 #dcdcdc, 0 0.425em 0 0 #cacaca, 0 0.425em 0.5em 0 #cecece;
  transition: 0.23s ease;
  cursor: pointer;
  font-weight: bold;
  margin: -1px;
}

.middle {
  border-radius: 0px;
}

.right {
  border-top-right-radius: 0.5em;
  border-bottom-right-radius: 0.5em;
}

.left {
  border-top-left-radius: 0.5em;
  border-bottom-left-radius: 0.5em;
}

.btn:active {
  translate: 0 0.225em;
  box-shadow: inset 0 0.03em 0 0 #f4f4f4, 0 0.03em 0 0 #efefef,
    0 0.0625em 0 0 #ececec, 0 0.125em 0 0 #e0e0e0, 0 0.125em 0 0 #dedede,
    0 0.2em 0 0 #dcdcdc, 0 0.225em 0 0 #cacaca, 0 0.225em 0.375em 0 #cecece;
  letter-spacing: 0.1em;
  color: #6e662766;
}

.btn:focus {
  color: #6e662766;
}
</style>
