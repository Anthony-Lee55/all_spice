import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { FavoriteRecipe } from "@/models/Favorite.js"
import { AppState } from "@/AppState.js"

class FavoritesService{
  async createFavorite(favoriteData) {
    const response = await api.post('api/favorites', favoriteData)
    logger.log("CREATED FAVORITE", response.data)
    const recipe = new FavoriteRecipe(response.data)
    AppState.FavoriteRecipes.push(recipe)
  }

}

export const favoritesService = new FavoritesService()