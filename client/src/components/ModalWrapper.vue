<script setup>
import RecipeForm from './RecipeForm.vue';


defineProps({
  modalId: { type: String, required: true },
  showFooter: { type: Boolean, default: false },
  modalTitle: { type: String, default: "Don't forget your title!" }
})
</script>


<template>
  <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title" :id="modalId + 'Label'">{{ modalTitle }}</h1>
          <button class="btn-close" type="button" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <RecipeForm />
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>