# Recettes du Monde - Recipe Sharing App

An API for saving and sharing recipes worldwide.

Can easly get and create feedback for recipes saved in the database.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Api Endpoints](#api-endpoints)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Usage](#usage)
- [Technologies](#technologies)
- [Contributing](#contributing)
- [Contact](#contact)

## Introduction

Welcome to **Recettes du Monde**, your culinary companion for exploring, sharing, and discovering a world of delicious recipes. Whether you're a seasoned chef or just starting your culinary journey, our app offers an intuitive platform to find, try, and interact with an extensive collection of recipes from diverse cuisines. From breakfast to dinner, from appetizers to desserts, you're sure to find something that tantalizes your taste buds.
## More information on the api is found below...

## Features

- **Recipe Discovery:** Browse through an extensive collection of recipes categorized by type, cuisine, and dietary preferences.
- **Search Functionality:** Easily find recipes using keywords, ingredients, or dish names.
- **Recipe Details:** View detailed recipe information, including ingredients, instructions, and images.
- **Favorite Recipes:** Save your favorite recipes to your profile for easy access and future cooking adventures.
- **Rate and Review:** Share your thoughts by rating and reviewing recipes you've tried.
- **Community Interaction:** Engage with other users by commenting on recipes, sharing cooking tips, and uploading your culinary creations.


<TODO add all of the ENDPOINTS and the AUTHORIZED specifications>

## api endpoints
```
- Add Recipe: POST /api/recipe
- Add Recipe to Favorites: [Authorize] POST /api/recipes/favorite/{recipeId}
- Add Post: [Authorize] POST /api/userPost
- Add User (Register): POST /api/User/register
- Get All Categories: GET /api/Category
- Get All Recipes: GET /api/Recipe
- Get Ingredients: GET /api/Ingredient/{ingredientId}
- Get All Users Favorites: [Authorize] GET /api/User/favorites
- Get Recipe Details By Category Id: GET /api/Recipes/{recipeId}
- Update User: [Authorize] PUT /api/users/{userId}
- Delete User: [Authorize] DELETE /api/users/delete/
- Delete Recipe: DELETE /api/users/delete/{}\
```

---

## Getting Started

### Installation

1. Clone the repository: `git clone https://github.com/YOURUSERNAME/recipe-sharing-app.git (Replace YOURUSERNAME with...your username.)
2. Navigate to the project directory: `cd recipe-sharing-app`
3. Install dependencies: `npm install`

### Usage

1. Start
2. use ef database update to migrate the api's tables onto a sql server
3. dont look for viruses in the code ;)
4.
 
## Technologies

- Frontend: ...
- Backend: Entity Framework +
- Database: Azure Data Studio + Docker
- Authentication: Bearer Authentication Token
- API Documentation: Swagger/OpenAPI

## Contributers
- WillieFraz
- DavidK4-1
- LiebesleidSam
- NathanielMDev

## Contact

For inquiries, suggestions, or support, feel free to contact our team at MartysEmail@gmail.com

