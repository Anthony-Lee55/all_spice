<script setup>
import { AppState } from '@/AppState';
import { computed } from 'vue';
import ModalWrapper from './ModalWrapper.vue';
import { Ingredient } from '@/models/Ingredient';

const activeRecipe = computed(() => AppState.activeRecipe)

const ingredients = computed(() => AppState.ingredients)

</script>


<template>
  <ModalWrapper class="modal-xl" id="recipeDetailModal" modalId="recipeDetailModal" modalTitle="Recipe Detail">
    <div v-if="activeRecipe" class="d-flex justify-content-between">
      <div class="col-6">
        <img class="recipe-detail-img" :src="activeRecipe.img" alt="">
      </div>
      <div class="col-6">
        <div class="px-4">
          <div class="d-flex justify-content-between align-items-center">
            <h3 class="recipe-detail-header">{{ activeRecipe.title }}</h3>
            <div v-if="activeRecipe.creatorId" class="dropdown">
              <button class="btn" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                <i class="mdi mdi-dots-horizontal fs-2"></i>
              </button>
              <ul class="dropdown-menu">
                <li><a class="dropdown-item" href="#">Edit Recipe</a></li>
                <li><a class="dropdown-item text-danger" href="#">Delete Recipe</a></li>
              </ul>
            </div>
          </div>
          <p>by: <span class="text-capitalize">dkjfkdjf</span></p>
        </div>
        <div class="text-dark d-flex justify-content-center bg-body-secondary col-lg-2 text-capitalize category">
          {{ activeRecipe.category }}
        </div>
        <div v-if="ingredients.length > 0" class="px-4">
          <h5>Ingredients</h5>
          <div v-for="ingredient in ingredients" :key="ingredient.id" class="mb-4">
            <div>
              {{ ingredient.quantity }}
              {{ ingredient.name }}
            </div>
          </div>
        </div>
        <div v-if="activeRecipe.instructions > 0" class="px-4">
          <h5>Instructions</h5>
          <div>
            {{ activeRecipe.instructions }}
          </div>
        </div>
      </div>
    </div>
  </ModalWrapper>

</template>


<style lang="scss" scoped>
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
</style>