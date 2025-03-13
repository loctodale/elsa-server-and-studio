using Microsoft.AspNetCore.Mvc;
using Elsa.Identity;
using Elsa.Identity.Services;
using System.Threading.Tasks;
using System.Threading;
using Elsa.Identity.Contracts;
using Elsa.Identity.Endpoints.Login;

namespace ElsaServer.Controllers
{
    [Route("identity")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserCredentialsValidator _userCredentialsValidator;
        private readonly IAccessTokenIssuer _tokenIssuer;

        public AuthController(IUserCredentialsValidator userCredentialsValidator, IAccessTokenIssuer tokenIssuer)
        {
            _userCredentialsValidator = userCredentialsValidator;
            _tokenIssuer = tokenIssuer;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Request request, CancellationToken cancellationToken)
        {
            var user = await _userCredentialsValidator.ValidateAsync(request.Username.Trim(), request.Password.Trim(), cancellationToken);

            if (user == null)
                return Unauthorized(new { success = false, accessToken = (string?)null, refreshToken = (string?)null });

            var tokens = await _tokenIssuer.IssueTokensAsync(user, cancellationToken);

            return Ok(new { success = true, accessToken = tokens.AccessToken, refreshToken = tokens.RefreshToken });
        }
    }

    
}