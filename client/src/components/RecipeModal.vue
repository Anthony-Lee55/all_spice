<script setup>
import { AppState } from '@/AppState';
import { computed, ref } from 'vue';
import ModalWrapper from './ModalWrapper.vue';
import { Ingredient } from '@/models/Ingredient';
import { logger } from '@/utils/Logger';
import Pop from '@/utils/Pop';
import { ingredientsService } from '@/services/IngredientsService';
import { recipesService } from '@/services/RecipesService';
import { Recipe } from '@/models/Recipe';

defineProps({
  recipe: { type: Recipe, required: true }
})

const activeRecipe = computed(() => AppState.activeRecipe)

const ingredients = computed(() => AppState.ingredients)

const account = computed(() => AppState.account)

const editableIngredientData = ref({
  name: '',
  quantity: '',
  recipeId: null
})

const editableInstructionData = ref({
  instructions: '',
  recipeId: null
})

async function addIngredient() {
  try {
    editableIngredientData.value.recipeId = AppState.activeRecipe.id
    await ingredientsService.addIngredient(editableIngredientData.value)
    editableIngredientData.value =
    {
      name: '',
      quantity: '',
      recipeId: null
    }
  }
  catch (error) {
    Pop.meow(error);
    logger.log("ADDING INGREDIENT TO RECIPE", error)
  }

}
async function addInstructions() {
  try {
    editableInstructionData.value.recipeId = AppState.activeRecipe.id
    await recipesService.addInstructions(editableInstructionData.value)
    editableInstructionData.value =
    {
      instructions: '',
      recipeId: null
    }
  }
  catch (error) {
    Pop.meow(error);
    logger.log("ADDING INSTRUCTION TO RECIPE", error)
  }
}

async function deleteRecipe(recipeId) {
  try {
    const confirm = await Pop.confirm("Do you really want to delete this recipe?")
    if (!confirm) return
    await recipesService.deleteRecipe(recipeId)
  }
  catch (error) {
    Pop.meow(error);
    logger.log("DELETING RECIPE", error)
  }
}

async function deleteIngredient(ingredientId) {
  try {
    await ingredientsService.deleteIngredient(ingredientId)
  }
  catch (error) {
    Pop.meow(error);
    logger.log("DELETING INGREDIENT", error)
  }
}
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
            <button @click="deleteRecipe(activeRecipe.id)" v-if="activeRecipe.creatorId == account.id"
              class="btn text-danger fs-1" title="Delete Recipe"><i class="mdi mdi-trash-can"></i></button>
          </div>
          <p>by: <span class="text-capitalize">{{ account.name }}</span></p>
        </div>
        <div class="text-dark d-flex justify-content-center bg-body-secondary col-lg-2 text-capitalize category">
          {{ activeRecipe.category }}
        </div>
        <div v-if="ingredients.length > 0" class="px-4">
          <h5>Ingredients</h5>
          <div v-for="ingredient in ingredients" :key="ingredient.id" class="mb-2 d-flex align-items-center">
            <button @click="deleteIngredient(ingredient.id)" v-if="activeRecipe.creatorId == account.id"
              class="btn text-danger fs-3"><i class="mdi mdi-alpha-x-circle"></i></button>
            <div>
              {{ ingredient.quantity }}
              {{ ingredient.name }}
            </div>
          </div>
        </div>
        <form v-if="activeRecipe.creatorId == account.id" @submit="addIngredient()">
          <div class="d-flex gap-3 align-items-center mx-2">
            <div class="col-4">
              <label for="ingredientQuantity">Ingredient Quantity</label>
              <input v-model="editableIngredientData.quantity" class=" form-control" id="ingredientQuantity" type="text"
                required>
            </div>
            <div class="col-6">
              <label for="ingredientName">Ingredient Name</label>
              <input v-model="editableIngredientData.name" class=" form-control" id="ingredientName" type="text"
                required>
            </div>
            <button type="submit" class="btn border-0 fs-3 text-success"><i class="mdi mdi-plus-circle"></i></button>
          </div>
        </form>
        <div v-if="activeRecipe.instructions" class="px-4">
          <h5>Instructions</h5>
          <div>
            {{ activeRecipe.instructions }}
          </div>
        </div>
        <form v-if="activeRecipe.creatorId == account.id" @submit="addInstructions()">
          <div class="d-flex gap-3 align-items-center mx-2 py-3">
            <div class="col-10 form-control">
              <label for="instruction">Instructions</label>
              <input v-model="editableInstructionData.instructions" class=" form-control" id="instruction" type="text"
                required>
            </div>
          </div>
          <div class="d-flex justify-content-end">
            <button type="submit" class="btn btn-success text-light">Save</button>
          </div>
        </form>
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