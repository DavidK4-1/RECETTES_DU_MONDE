# Recettes Du Monde

An API for saving and sharing recipes worldwide.

Can easly get and create feedback for recipes saved in the database.

## More information on the api is found below...

## features
```
- descover recipes
- rate and review
- create recipes
- includes tokenized authentication for users and password encryption
```

<TODO add all of the ENDPOINTS and the AUTHORIZED specifications>

## api endpoints
```
- Add Recipe: POST /api/recipe
- Add Recipe to Favorites: [Authorize] POST /api/recipes/favorite/{recipeId}
- Add Post: [Authorize] POST /api/post
- Add User (Register): POST /api/User/register
- Get All Categories: GET /api/Category
- Get All Recipes: GET /api/Recipe
- Get Ingredients: GET /api/Ingredient/{ingredientId}
- Get All User Favorites: GET /api/User/favorites
- Get Recipe Details By Category Id: GET /api/recipes/{recipeId}
- Get User Favorite by Id: GET /api/users/favorite/{recipeId}
- Update User: [Authorize] PUT /api/users/update/{userId}
- Delete User: [Authorize] DELETE /api/users/delete/
- Delete Recipe: DELETE /api/users/delete/{}\
```

---

### Installation

1. Clone the repository: `git clone https://github.com/YOURUSERNAME/recipe-sharing-app.git`

2. Navigate to the project directory: `cd recipe-sharing-app`

3. Install dependencies: `npm install`

### other resources
- https://dbdiagram.io/d/64da363b02bd1c4a5ebfd9fb
