# Recettes du Monde - Recipe Sharing App

## Introduction

Welcome to **Recettes du Monde**, your culinary companion for exploring, sharing, and discovering a world of delicious recipes. Whether you're a seasoned chef or just starting your culinary journey, our app offers an intuitive platform to find, try, and interact with an extensive collection of recipes from diverse cuisines. From breakfast to dinner, from appetizers to desserts, you're sure to find something that tantalizes your taste buds.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Api Endpoints](#api-endpoints)
- [Api Endpoint Usage](#api-endpoint-usage)
    - [User Usage](#user-usage)
    - [Ingredient Usage](#ingredient-usage)
    - [Recipe Usage](#recipe-usage)
    - [Category Usage](#category-usage)
    - [UserFavorites Usage](#userFavorites-usage)
    - [UserPost Usage](#userPost-usage)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Tour of Api](#tour-of-api)
- [Technologies](#technologies)
- [Planning Documents](#planning-documents)
- [Contributing](#contributing)
- [Contact](#contact)


## Features

**Recipe Discovery** 
: Browse through an extensive collection of recipes categorized by type, cuisine, and dietary preferences.

 **Search Functionality** 
 : Easily find recipes using keywords, ingredients, or dish names.
 
**Recipe Details** 
: View detailed recipe information, including ingredients, instructions, and images.

**Favorite Recipes** 
: Save your favorite recipes to your profile for easy access and future cooking adventures.

**Rate and Review** 
: Share your thoughts by rating and reviewing recipes you've tried.

**Community Interaction**
: Engage with other users by commenting on recipes, sharing cooking tips, and uploading your culinary creations.


## API Endpoints

### User
- Add a User: POST /api/User/register
- Get User Token: POST /api/Token
- Update User information: PUT /api/User/update
- Delete User: DELETE /api/User/Delete

### Ingredient
- Add an Ingredient: POST /api/Ingredient/register
- Get all Ingredients: GET /api/Ingredient
- Get Ingredient by Id: GET /api/Ingredient/{Id}

### Recipe
- Add a Recipe: POST /api/Recipe
- Get all Recipes: GET /api/Recipe
- Get Recipe: GET /api/Recipe/{recipeId}
- Get Recipes by Category: GET /category/{categoryId}
- Get Recipe by Ingredient: GET /GetByIngredient/{id}
- Delete Recipe: DELETE /api/Recipe/{recipeId}

### Category
- Add a Category: POST /api/Category
- Add a Recipe to a Category: PUT /api/Category/{categoryId}/{recipeId}
- Get a list of Categories: GET /api/Category
- Delete a Category: DELETE /api/Category/{categoryId}

### UserFavorites
- Create Favorites List: POST /api/UserFavorites
- Get your Favorites: GET /api/UserFavorites
- Add a Recipe to Favorites: PUT /api/UserFavorites/{recipeId}
- Delete Recipe from Favorites: DELETE /api/UserFavorites/{recipeId}

### UserPost
- Add a Post to Recipe: POST /api/UserPost
- Get the Recipe Posts: GET /api/UserPost/{recipeId}
- Delete a Post: DELETE /api/UserPost/Delete/{userPostId}
- Delete a Recipe's Posts: DELETE /api/UserPost/{recipeId}


## Api Endpoint Usage

### User Usage
 1. Register a User account using the:  **Add a User** endpoint.
 `Add a User: POST /api/User/register`
 
 2. Generate a UserToken using the: **Get User Token** endpoint.
 `Get User Token: POST /api/Token`
 (Your **User Token** will allow you access to endpoints that require user authentication)
 
  3. Update User information using the:  **Update User Information** endpoint.
 `Update User information: PUT /api/User/update`
 
   4. Delete your User using the:  **Delete User** endpoint.
 `Delete User: DELETE /api/User/Delete`

### Ingredient Usage

 1. Add an Ingredient using the **Add an Ingredient** endpoint.
 `Add an Ingredient: POST /api/Ingredient/register`
 
  2. Get all available Ingredients using the: **Get all Ingredients** endpoint.
 `Get all Ingredients: GET /api/Ingredient`
 
 2. Get Ingredient by Id using the: **Get Ingredient by Id** endpoint.
 `Get Ingredient by Id: GET /api/Ingredient/{Id}`
 
### Recipe Usage
 1. Add a Recipe using the:  **Add a Recipe** endpoint.
 `Add a Recipe: POST /api/Recipe`
 
 2. Get all available Recipes using the: **Get all Recipes** endpoint.
 `Get all Recipes: GET /api/Recipe`
 
  3. Get a Recipe by Id using the: **Get Recipe** endpoint.
 `Get Recipe: GET /api/Recipe/{recipeId}`
 
   4. Get Recipe by associated Categories using the: **Get Recipes by Category** endpoint.
 `Get Recipes by Category: GET /category/{categoryId}`
 
 5. Get a Recipe by associated Ingredients using the: **Get Recipe by Ingredient** endpoint.
 `Get Recipe by Ingredient: GET /GetByIngredient/{id}`
 
 6. Delete a Recipe using the: **Delete Recipe** endpoint.
 `Delete Recipe: DELETE /api/Recipe/{recipeId}`
 
### Category Usage

1. Add a Category using the: **Add a Category** endpoint.
`Add a Category: POST /api/Category`

2. Add a Recipe to a Category using the: **Add a Recipe to a Category** endpoint.
`Add a Recipe to a Category: PUT /api/Category/{categoryId}/{recipeId}`
3. Get a list of Categories using the: **Get a list of Categories** endpoint.
`Get a list of Categories: GET /api/Category`
4. Delete a Category using the: **Delete a Category** endpoint.
`Delete a Category: DELETE /api/Category/{categoryId}`

### UserFavorites Usage
*User and Authentication Required*
1. Create a Favorites List using the: **Create Favorites List** endpoint.
`Create Favorites List: POST /api/UserFavorites`

2. Get your Favorites using the: **Get your Favorites** endpoint.
`Get your Favorites: GET /api/UserFavorites`

 3. Add a Recipe to Favorites using the: **Add a Recipe to Favorites** endpoint.
`Add a Recipe to Favorites: PUT /api/UserFavorites/{recipeId}`

4. Delete Recipe from Favorites using the: **Delete Recipe from Favorites** endpoint.
`Delete Recipe from Favorites: DELETE /api/UserFavorites/{recipeId}`

### UserPost Usage

1. Add a Post to Recipe using the: **Add a Post to Recipe** endpoint.
`Add a Post to Recipe: POST /api/UserPost`

2. Get the Recipe Posts using the: **Get the Recipe Posts** endpoint.
`Get the Recipe Posts: GET /api/UserPost/{recipeId}`

3. Delete a Post using the: **Delete a Post** endpoint.
`Delete a Post: DELETE /api/UserPost/Delete/{userPostId}`

4. Delete a Recipe's Posts using the: **Delete a Recipe's Posts** endpoint.
`Delete a Recipe's Posts: DELETE /api/UserPost/{recipeId}`

# Getting Started

## Installation

1. Clone the repository: `git clone https://github.com/YOURUSERNAME/recipe-sharing-app.git *(Replace YOURUSERNAME with...your username.)*
2. Navigate to the project directory: `cd recipe-sharing-app`
3. Install dependencies: `npm install`
4. Run  `dotnet ef migrations add InitialCreate` to create migrations folder.


## Tour of Api

1. **Create a User**:
   - To get started, register a new user account using the **Add a User** endpoint.
   - `POST /api/User/register`

2. **Generate Token and Set Authorization**:
   - After creating a user, use the **Get User Token** endpoint to generate an authentication token.
   -  `Get User Token: POST /api/Token`
   - Save the generated token and set it as a **Bearer Token** in your Postman requests for subsequent authenticated endpoints.

3. **Create an Ingredient**:
   - Add new ingredients to your collection using the **Add an Ingredient** endpoint.
   - `POST /api/Ingredient/register`

4. **Create a Recipe**:
   - Share your culinary creations with the community by adding a new recipe using the **Add a Recipe** endpoint.
   - `POST /api/Recipe`

5. **Create a Category**:
   - Organize your recipes by adding them to specific categories using the **Add a Recipe to a Category** endpoint.
   - `PUT /api/Category/{categoryId}/{recipeId}`

6. **Add Recipe to User Favorites**:
   - Generate a favorites list by using the **Create Favorites List** endpoint.
   - Then, add a recipe to your favorites list using the **Add a Recipe to Favorites** endpoint.
   - `POST /api/UserFavorites` and `PUT /api/UserFavorites/{recipeId}`

7. **Make a User Post on Your Recipe**:
   - Engage with the community by sharing your thoughts on a recipe. Post a comment using the **Add a Post to Recipe** endpoint.
   -  `POST /api/UserPost`

Remember to replace placeholders such as `{categoryId}`, `{recipeId}`, and `{userPostId}` with actual values.

 
## Technologies

- Backend: Entity Framework
- Database: Azure Data Studio + Docker
- Authentication: Bearer Authentication Token
- API Documentation: Swagger/OpenAPI

## Planning Documents

- [DB Diagram](https://dbdiagram.io/d/64da363b02bd1c4a5ebfd9fb)
- [Trello Board](https://trello.com/b/DQIPg6kH/recipe-userstory)
- [Google Docs](https://docs.google.com/document/d/15BFhsq8ASy-8vI4Ub3ciGDendiP8PsPKBty6D_ras44/edit)

## Contributers
- WillieFraz
- DavidK4-1
- LiebesleidSam
- NathanielMDev

## Contact

For inquiries, suggestions, or support, feel free to contact our team at nathanielmatlack@gmail.com
