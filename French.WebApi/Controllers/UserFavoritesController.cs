using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using French.Data.Entities;
using French.Services.UserFavoritesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace French.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoritesController : ControllerBase
    {
        private readonly IUserFavoritesService _userFavoritesService;

        public UserFavoritesController(IUserFavoritesService UserFavoritesService)
        {
            _userFavoritesService = UserFavoritesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFavorites()
        {
            var favorites = await _userFavoritesService.GetAllFavoritesAsync();
            return Ok(favorites); //Return Favorites
        }
    }
}
