import { AppState } from "@/AppState.js"
import { api } from "./AxiosService.js"
import { logger } from "@/utils/Logger.js"
import { Ingredient } from "@/models/Ingredient.js"


class IngredientsService{
  async addIngredient(ingredientData) {
    const response = await api.post('api/ingredients', ingredientData)
    logger.log(response.data)
    // const ingredient 
  }
  }



export const ingredientsService = new IngredientsService()