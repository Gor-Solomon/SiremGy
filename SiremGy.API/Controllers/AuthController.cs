using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiremGy.BLL.Interfaces.Exceptions;
using SiremGy.BLL.Interfaces.Users;
using SiremGy.Models.Users;

namespace SiremGy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost(nameof(RegisterUser))]
        public async Task<IActionResult> RegisterUser(UserModel userModel)
        {
            IActionResult actionResult;

            try
            {
                var result = await _usersService.RegisterUser(userModel);
                actionResult = CreatedAtRoute("",result);
            }
            catch (BLLException ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            catch(Exception)
            {
                actionResult = StatusCode(500);
            }

            return actionResult;
        }

    }
}
