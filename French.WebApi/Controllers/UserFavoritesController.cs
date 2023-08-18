using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using French.Services.UserFavoritesService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace French.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoritesController : ControllerBase
    {
        private readonly IUserFavoriteService _userFavoritesService;

        public UserFavoritesController(IUserFavoriteService UserFavoritesService)
        {
            _userFavoritesService = UserFavoritesService;
        }
    }
}
