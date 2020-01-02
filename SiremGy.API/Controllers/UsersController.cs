using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiremGy.BLL.Interfaces.Users;
using SiremGy.BLL.Models.Users;

namespace SiremGy.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            this._usersService = usersService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _usersService.GetUsers();
            return Ok(result.Value);
        }

        [HttpGet("{id}", Name = nameof(GetUsers))]
        public async Task<IActionResult> GetUsers(int id)
        {
            var result = await _usersService.GetUser(id);
            return Ok(result.Value);
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
