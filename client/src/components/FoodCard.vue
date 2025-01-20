<script setup>
import { Recipe } from '@/models/Recipe';


defineProps({
  recipe: { type: Recipe, required: true }
})

</script>


<template>
  <div class="card">
    <p>{{ recipe.title }}</p>
  </div>
</template>


<style lang="scss" scoped></style>