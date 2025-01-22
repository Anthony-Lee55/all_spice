import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "@/models/Recipe.js"
import { AppState } from "@/AppState.js"


class RecipesService{
  async createRecipe(recipeData) {
    const response = await api.post('api/recipes', recipeData)
    logger.log("CREATED RECIPE", response.data)
    const recipe = new Recipe(response.data)
    AppState.recipes.unshift(recipe)
  }
  async getRecipes() {
    const response = await api.get('api/recipes')
    logger.log("GOT RECIPES", response.data)
    const recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
    AppState.recipes = recipes
  }

    async getRecipeById(recipeId) {
      AppState.activeRecipe = null
      const response = await api.get(`api/recipes/${recipeId}`)
      logger.log("GOT RECIPE BY ID", response.data)
      const recipe = new Recipe(response.data)
      AppState.activeRecipe = recipe
    }
}

export const recipesService = new RecipesService()