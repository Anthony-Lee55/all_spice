<script setup>
import { Recipe } from '@/models/Recipe';
import FoodCard from './FoodCard.vue';


defineProps({
  recipe: { type: Recipe, required: true }
})
</script>


<template>
  <div data-bs0toggle="modal" data-bs-target="#recipeModal">
    <ModalWrapper modalId="recipeDetailModal" modalTitle="Recipe Detail">
      <FoodCard />
    </ModalWrapper>
  </div>
</template>


<style lang="scss" scoped></style>