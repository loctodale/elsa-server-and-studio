using Elsa.Api.Client.Resources.Identity.Responses;
using FastEndpoints;
using Elsa.Identity;
using Elsa.Identity.Services;
using System.Threading;
using System.Threading.Tasks;
using Elsa.Identity.Contracts;
using Elsa.Identity.Endpoints.Login;

namespace ElsaServer;

public class Login : Endpoint<Request, LoginResponse>
{
    private readonly IUserCredentialsValidator _userCredentialsValidator;
    private readonly IAccessTokenIssuer _tokenIssuer;

    public Login(IUserCredentialsValidator userCredentialsValidator, IAccessTokenIssuer tokenIssuer)
    {
        _userCredentialsValidator = userCredentialsValidator;
        _tokenIssuer = tokenIssuer;
    }
    public override void Configure()
    {
        Post("/identity/login");
        AllowAnonymous();
    }

    public override async Task<LoginResponse> ExecuteAsync(Request request, CancellationToken cancellationToken)
    {
        var user = await _userCredentialsValidator.ValidateAsync(request.Username.Trim(), request.Password.Trim(), cancellationToken);

        if (user == null)
            return new LoginResponse(false, null, null);

        var tokens = await _tokenIssuer.IssueTokensAsync(user, cancellationToken);

        return new LoginResponse(true, tokens.AccessToken, tokens.RefreshToken);
    }

}