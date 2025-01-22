

export class Ingredient{
  constructor(data){
this.id = data.id
this.created_at = new Date(data.created_at)
this.updated_at = new Date(data.updated_at)
this.name = data.name
this.quantity = data.quantity
this.recipe_id = data.recipe_id
  }
}