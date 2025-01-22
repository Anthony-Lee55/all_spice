<script setup>
import { Account } from '@/models/Account';
import { recipesService } from '@/services/RecipesService';
import { logger } from '@/utils/Logger';
import Pop from '@/utils/Pop';
import { Modal } from 'bootstrap';
import { ref } from 'vue';
import RecipeModal from './RecipeModal.vue';


defineProps({
  account: {type:Account}
})



const categories = ['breakfast', 'lunch', 'dinner', 'snack', 'dessert']

const editableFormData = ref({
  title: '',
  category: '',
  img: ''
})

async function createRecipe() {
  try {
    await recipesService.createRecipe(editableFormData.value)
    editableFormData.value = {
      title: '',
      category: '',
      img: ''
    }
    Modal.getInstance('#recipeModal').hide()
  } catch (error) {
    Pop.meow(error);
    logger.log("CREATING RECIPE", error)
    Modal.getInstance('#recipeDetailModal').show()
  }
}

</script>


<template>
  <form @submit.prevent="createRecipe()" class="form">
    <h1>New Recipe</h1>
    <div class="d-flex justify-content-between gap-2">
      <div class="form-floating mb-4 col-6">
        <input v-model="editableFormData.title" type="text" class="form-control" id="title" placeholder="Title..."
          required minlength="3" maxlength="255">
        <label for="title">Title</label>
      </div>
      <div class="form-floating mb-4 col-6">
        <select v-model="editableFormData.category" class="form-select text-capitalize" id="category"
          aria-label="Category" required>
          <option selected value="" disabled>Category</option>
          <option v-for="category in categories" :key="category" :value="category" class="text-capitalize">
            {{ category }}
          </option>
        </select>
        <label for="category">Category</label>
      </div>
    </div>
    <div class="d-flex gap-1">
      <div class="form-floating col-10">
        <input v-model="editableFormData.img" type="url" class="form-control" id="img" placeholder="Image Url..."
          required maxlength="1000">
        <label for="img">Image</label>
      </div>
      <div class="text-end col-2">
        <button class="btn btn-warning" type="submit">Submit</button>
      </div>
    </div>
  </form>

  <RecipeModal/>
</template>


<style lang="scss" scoped></style>