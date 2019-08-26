using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models;

namespace TSM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IAppLogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(
            IAppLogger<UsersController> logger,
            IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAdminModel>>> GetUsers()
        {
            var user = await _userService.GetUsers();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAdminModel>> GetUser(string id)
        {
            var user = await _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<IdentityResult>> PostUser(UserAdminModel requestModel)
        {
            var identityResult = await _userService.CreateUser(requestModel);

            return Ok(identityResult);
        }

        [HttpPut]
        public async Task<ActionResult<IdentityResult>> PutUser(UserAdminModel requestModel)
        {
            var identityResult = await _userService.UpdateUser(requestModel);

            return Ok(identityResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IdentityResult>> DeleteUser(string id)
        {
            var identityResult = await _userService.DeleteUser(id);

            return Ok(identityResult);
        }
    }
}