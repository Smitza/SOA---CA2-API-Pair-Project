using ImplementAPIKeyAuthentication.Interface;
using Microsoft.AspNetCore.Mvc;
/*
 * Use of Api key used in this tutorial.
 *  https://code-maze.com/aspnetcore-api-key-authentication/
 *  
 */

namespace ImplementAPIKeyAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiKeyController : ControllerBase
    {
        private readonly IApiKeyValidation _apiKeyValidation;

        public ApiKeyController(IApiKeyValidation apiKeyValidation)
        {
            _apiKeyValidation = apiKeyValidation;
        }

        [HttpGet]
        public IActionResult AuthenticateViaQueryParam(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                return BadRequest();

            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);

            if (!isValid)
                return Unauthorized();

            return Ok();
        }
    }
}
