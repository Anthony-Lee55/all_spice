import { AppState } from "@/AppState.js"
import { api } from "./AxiosService.js"
import { logger } from "@/utils/Logger.js"
import { Ingredient } from "@/models/Ingredient.js"


class IngredientsService{
  async addIngredient(ingredientData) {
    const response = await api.post('api/ingredients', ingredientData)
    logger.log(response.data)
    const ingredient = new Ingredient(response.data)
    AppState.ingredients.push(ingredient)
  }

  async deleteIngredient(ingredientId) {
    const response = await api.delete(`api/ingredients/${ingredientId}`)
    logger.log("DELETED INGREDIENT", response.data)
    const ingredientIndex = AppState.ingredients.findIndex(ingredient => ingredient.id == ingredientId)
    AppState.ingredients.splice(ingredientIndex, 1)
  }
}



export const ingredientsService = new IngredientsService()