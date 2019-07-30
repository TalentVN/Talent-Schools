using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models.RequestModels;
using TSM.Models.ResponseModels;

namespace TSM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IAppLogger<IdentityController> _logger;

        public IdentityController(
           IIdentityService identityService,
           IAppLogger<IdentityController> logger)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateUserResponseModel>> Create([FromBody] CreateUserRequestModel requestModel)
        {
            var result = await _identityService.Create(requestModel.FirstName, requestModel.LastName, requestModel.Email, requestModel.PassWord);

            return Ok(result);
        }

        [Route("ConfirmEmail")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> ConfirmEmail([FromBody] EmailConfirmationRequestModel requestModel)
        {
            var result = await _identityService.ConfirmEmail(requestModel.UserId, requestModel.Code);

            return Ok(result);
        }

        [Route("Login")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginRequestModel requestModel)
        {
            var result = await _identityService.Login(requestModel.UserName, requestModel.PassWord);

            return Ok(result);
        }
    }
}