

export class FavoriteRecipe{
  constructor(data){
    this.id = data.id
    this.createdAt =new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.favoriteId = data.favoriteId
    this.accountId = data.accountId
    this.recipeId = data.recipeId
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.creatorId = data.creatorId
    this.creator = data.creator
  }
}